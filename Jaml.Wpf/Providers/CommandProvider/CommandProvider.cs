using System;
using System.Collections.Generic;

namespace Jaml.Wpf.Providers.CommandProvider
{
    // ReSharper disable once ClassCanBeSealed.Global
    public class CommandProvider : ICommandProvider
    {
        #region Properties

        public Dictionary<string, Delegate> CommandsDictionary { get; }

        #endregion

        #region Constructors

        public CommandProvider(Dictionary<string, Delegate> commandsDictionary) => CommandsDictionary = commandsDictionary;

        public CommandProvider() => CommandsDictionary = new Dictionary<string, Delegate>();

        #endregion

        #region Methods

        public void RegisterCommands(Dictionary<string, Delegate> commands)
        {
            foreach ((string commandName, Delegate command) in commands) RegisterCommand(commandName, command);
        }

        public void UnregisterCommands(IEnumerable<string> commandNames)
        {
            foreach (string commandName in commandNames) UnregisterCommand(commandName);
        }

        public void ClearCommands() => CommandsDictionary.Clear();

        public void RegisterCommand(string commandName, Delegate command) => CommandsDictionary.TryAdd(commandName, command);

        public void UnregisterCommand(string commandName) => CommandsDictionary.Remove(commandName);

        public void AddToExistentCommand(string commandName, Delegate delegateToAdd)
        {
            Delegate firstDelegate = CommandsDictionary[commandName];
            CommandsDictionary[commandName] = Delegate.Combine(firstDelegate, delegateToAdd);
        }

        public void RemoveFromExistentCommand(string commandName, Delegate delegateToRemove)
        {
            Delegate firstDelegate = CommandsDictionary[commandName];
            CommandsDictionary[commandName] = Delegate.Remove(firstDelegate, delegateToRemove);
        }

        public void RunCommand(string commandName, object sender = null, string args = null)
        {
            if (string.IsNullOrWhiteSpace(commandName)) return;
            if (!CommandsDictionary.ContainsKey(commandName)) return;

            if (string.IsNullOrWhiteSpace(args))
                GetCommand(commandName).DynamicInvoke(sender);
            else
                GetCommand(commandName).DynamicInvoke(sender, args);
        }

        public Delegate GetCommand(string commandName)
        {
            CommandsDictionary.TryGetValue(commandName, out Delegate value);

            return value;
        }

        #endregion
    }
}
