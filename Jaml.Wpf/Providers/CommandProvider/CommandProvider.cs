using System;
using System.Collections.Generic;

namespace Jaml.Wpf.Providers.CommandProvider
{
    // ReSharper disable once ClassCanBeSealed.Global

    /// <inheritdoc />
    public class CommandProvider : ICommandProvider
    {
        #region Properties

        /// <inheritdoc />
        public Dictionary<string, Delegate> CommandsDictionary { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new <see cref="CommandProvider"/> with specified commands
        /// </summary>
        /// <param name="commandsDictionary">Commands for this provider</param>
        public CommandProvider(Dictionary<string, Delegate> commandsDictionary) => CommandsDictionary = commandsDictionary;

        /// <summary>
        /// Creates a new <see cref="CommandProvider"/> with empty dictionary of commands
        /// </summary>
        public CommandProvider() => CommandsDictionary = new Dictionary<string, Delegate>();

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
        public void ClearCommands() => CommandsDictionary.Clear();

        /// <inheritdoc />
        public void RegisterCommand(string commandName, Delegate command) => CommandsDictionary.TryAdd(commandName, command);

        /// <inheritdoc />
        public void UnregisterCommand(string commandName) => CommandsDictionary.Remove(commandName);

        /// <inheritdoc />
        public void AddToExistentCommand(string commandName, Delegate delegateToAdd)
        {
            Delegate firstDelegate = CommandsDictionary[commandName];
            CommandsDictionary[commandName] = Delegate.Combine(firstDelegate, delegateToAdd);
        }

        /// <inheritdoc />
        public void RemoveFromExistentCommand(string commandName, Delegate delegateToRemove)
        {
            Delegate firstDelegate = CommandsDictionary[commandName];
            CommandsDictionary[commandName] = Delegate.Remove(firstDelegate, delegateToRemove);
        }

        /// <inheritdoc />
        public void RunCommand(string commandName, object sender = null, string args = null)
        {
            if (string.IsNullOrWhiteSpace(commandName)) return;
            if (!CommandsDictionary.ContainsKey(commandName)) return;

            if (string.IsNullOrWhiteSpace(args))
                GetCommand(commandName).DynamicInvoke(sender);
            else
                GetCommand(commandName).DynamicInvoke(sender, args);
        }

        /// <inheritdoc />
        public Delegate GetCommand(string commandName)
        {
            CommandsDictionary.TryGetValue(commandName, out Delegate value);

            return value;
        }

        #endregion
    }
}
