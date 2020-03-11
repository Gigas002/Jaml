using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Jaml.Wpf.Constants;
using Jaml.Wpf.Models.CommandModels;

namespace Jaml.Wpf.Providers.CommandProvider
{
    // ReSharper disable once ClassCanBeSealed.Global

    /// <inheritdoc />
    public class CommandProvider : ICommandProvider
    {
        #region Properties

        /// <inheritdoc />
        public Dictionary<string, Delegate> Commands { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new <see cref="CommandProvider"/> with specified commands
        /// </summary>
        /// <param name="commands">Commands for this provider</param>
        public CommandProvider(Dictionary<string, Delegate> commands) => Commands = commands;

        /// <summary>
        /// Creates a new <see cref="CommandProvider"/> with empty dictionary of commands
        /// </summary>
        public CommandProvider() => Commands = new Dictionary<string, Delegate>();

        #endregion

        #region Methods

        /// <inheritdoc />
        public void RegisterCommands(Dictionary<string, Delegate> commands)
        {
            foreach ((string commandName, Delegate command) in commands) RegisterCommand(commandName, command);
        }

        /// <inheritdoc />
        public void UnregisterCommands(IEnumerable<string> commandNames)
        {
            foreach (string commandName in commandNames) UnregisterCommand(commandName);
        }

        /// <inheritdoc />
        public void ClearCommands() => Commands.Clear();

        /// <inheritdoc />
        public void RegisterCommand(string commandName, Delegate command) => Commands.TryAdd(commandName, command);

        /// <inheritdoc />
        public void UnregisterCommand(string commandName) => Commands.Remove(commandName);

        /// <inheritdoc />
        public void AddToExistentCommand(string commandName, Delegate delegateToAdd)
        {
            Delegate firstDelegate = Commands[commandName];
            Commands[commandName] = Delegate.Combine(firstDelegate, delegateToAdd);
        }

        /// <inheritdoc />
        public void RemoveFromExistentCommand(string commandName, Delegate delegateToRemove)
        {
            Delegate firstDelegate = Commands[commandName];
            Commands[commandName] = Delegate.Remove(firstDelegate, delegateToRemove);
        }

        /// <inheritdoc />
        public void RunCommand(string commandName, object sender, string args)
        {
            if (string.IsNullOrWhiteSpace(commandName)) return;
            if (!Commands.ContainsKey(commandName)) return;

            if (string.IsNullOrWhiteSpace(args))
                GetCommand(commandName).DynamicInvoke(sender);
            else
                GetCommand(commandName).DynamicInvoke(sender, args);
        }

        /// <inheritdoc />
        public Delegate GetCommand(string commandName)
        {
            Commands.TryGetValue(commandName, out Delegate value);

            return value;
        }

        /// <inheritdoc />
        public void BindCommand<T>(ref T element, ICommandModel commandModel) where T : UIElement
        {
            //todo use reflection, this is ugly

            string eventName = commandModel.Event;
            string methodName = commandModel.Method;
            string methodArgs = commandModel.Args;

            switch (eventName)
            {
                case EventNames.Initialized:
                    {
                        if (element is FrameworkElement frameworkElement)
                            frameworkElement.Initialized += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.Click:
                    {
                        if (element is ButtonBase button)
                            button.Click += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.MouseLeftButtonUp:
                    {
                        element.MouseLeftButtonUp += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewMouseLeftButtonUp:
                    {
                        element.PreviewMouseLeftButtonUp += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.MouseRightButtonUp:
                    {
                        element.MouseRightButtonUp += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.MediaEnded:
                    {
                        if (element is MediaElement mediaElement)
                            mediaElement.MediaEnded += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.Loaded:
                    {
                        if (element is FrameworkElement frameworkElement)
                            frameworkElement.Loaded += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                default: { throw new NotSupportedException($"Event {eventName} is not supported."); }
            }
        }

        /// <inheritdoc />
        public void BindCommands<T>(ref T element, IEnumerable<ICommandModel> commandModels) where T : UIElement
        {
            foreach (ICommandModel commandModel in commandModels) BindCommand(ref element, commandModel);
        }

        #endregion
    }
}
