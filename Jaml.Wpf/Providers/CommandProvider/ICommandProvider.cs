using System;
using System.Collections.Generic;

namespace Jaml.Wpf.Providers.CommandProvider
{
    public interface ICommandProvider
    {
        public Dictionary<string, Delegate> CommandsDictionary { get; }

        public void RegisterCommands(Dictionary<string, Delegate> commands);

        public void UnregisterCommands(IEnumerable<string> commandNames);

        public void ClearCommands();

        public void RegisterCommand(string commandName, Delegate command);

        public void UnregisterCommand(string commandName);

        public void AddToExistentCommand(string commandName, Delegate delegateToAdd);

        public void RemoveFromExistentCommand(string commandName, Delegate delegateToRemove);

        public void RunCommand(string commandName, object sender = null, string args = null);

        public Delegate GetCommand(string commandName);
    }
}
