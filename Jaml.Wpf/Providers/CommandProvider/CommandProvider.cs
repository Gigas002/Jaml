using System;
using System.Collections.Generic;
using Jaml.Wpf.Models.CommandModels;

namespace Jaml.Wpf.Providers.CommandProvider
{
    // ReSharper disable once ClassCanBeSealed.Global

    /// <inheritdoc />
    public class CommandProvider : ICommandProvider
    {
        #region Properties

        /// <inheritdoc />
        public Dictionary<string, Action<object, IEnumerable<ICommandArgModel>>> Commands { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new <see cref="CommandProvider"/> with specified commands
        /// </summary>
        /// <param name="commands">Commands for this provider</param>
        public CommandProvider(Dictionary<string, Action<object, IEnumerable<ICommandArgModel>>> commands) => Commands = commands;

        /// <summary>
        /// Creates a new <see cref="CommandProvider"/> with empty dictionary of commands
        /// </summary>
        public CommandProvider() => Commands = new Dictionary<string, Action<object, IEnumerable<ICommandArgModel>>>();

        #endregion

        #region Methods

        /// <inheritdoc />
        public void RegisterCommands(Dictionary<string, Action<object, IEnumerable<ICommandArgModel>>> commands)
        {
            foreach ((string commandName, Action<object, IEnumerable<ICommandArgModel>> command) in commands)
                RegisterCommand(commandName, command);
        }

        /// <inheritdoc />
        public void UnregisterCommands(IEnumerable<string> commandNames)
        {
            foreach (string commandName in commandNames) UnregisterCommand(commandName);
        }

        /// <inheritdoc />
        public void ClearCommands() => Commands.Clear();

        /// <inheritdoc />
        public void RegisterCommand(string commandName, Action<object, IEnumerable<ICommandArgModel>> command) =>
            Commands.TryAdd(commandName, command);

        /// <inheritdoc />
        public void UnregisterCommand(string commandName) => Commands.Remove(commandName);

        /// <inheritdoc />
        public void RunCommand(string commandName, object sender, IEnumerable<ICommandArgModel> args)
        {
            if (string.IsNullOrWhiteSpace(commandName)) return;
            if (!Commands.ContainsKey(commandName)) return;

            //GetCommand(commandName).DynamicInvoke(sender, args);
            GetCommand(commandName).Invoke(sender, args);
        }

        /// <inheritdoc />
        public Action<object, IEnumerable<ICommandArgModel>> GetCommand(string commandName)
        {
            Commands.TryGetValue(commandName, out Action<object, IEnumerable<ICommandArgModel>> value);

            return value;
        }

        #endregion
    }
}
