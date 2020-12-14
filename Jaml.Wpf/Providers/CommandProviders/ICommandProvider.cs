using System;
using System.Collections.Generic;
using Jaml.Wpf.Models.CommandModels;

namespace Jaml.Wpf.Providers.CommandProviders
{
    /// <summary>
    /// Base interface for command operations
    /// </summary>
    public interface ICommandProvider
    {
        /// <summary>
        /// Dictionary of commands. Key is name, and Value is action to run
        /// </summary>
        public Dictionary<string, Action<object, IEnumerable<ICommandArgModel>>> Commands { get; }

        /// <summary>
        /// Registers all commands from dictionary
        /// </summary>
        /// <param name="commands">Dictionary to register</param>
        public void RegisterCommands(Dictionary<string, Action<object, IEnumerable<ICommandArgModel>>> commands);

        /// <summary>
        /// Delete collection of commands with specified keys
        /// </summary>
        /// <param name="commandNames">Collection of keys to delete from dictionary</param>
        public void UnregisterCommands(IEnumerable<string> commandNames);

        /// <summary>
        /// Clears dictionary of commands
        /// </summary>
        public void ClearCommands();

        /// <summary>
        /// Registers one command
        /// </summary>
        /// <param name="commandName">Name of command</param>
        /// <param name="action">Action to run</param>
        public void RegisterCommand(string commandName, Action<object, IEnumerable<ICommandArgModel>> action);

        /// <summary>
        /// Delete the specified command from dictionary
        /// </summary>
        /// <param name="commandName">Command name to delete</param>
        public void UnregisterCommand(string commandName);

        /// <summary>
        /// Starts the command
        /// </summary>
        /// <param name="commandName">Name of command to start</param>
        /// <param name="sender">Sender of command</param>
        /// <param name="args">Arguments for command</param>
        public void RunCommand(string commandName, object sender, IEnumerable<ICommandArgModel> args);

        /// <summary>
        /// Gets command by name
        /// </summary>
        /// <param name="commandName">Name of command to get</param>
        /// <returns>Command's <see cref="Action{T}"/></returns>
        public Action<object, IEnumerable<ICommandArgModel>> GetCommand(string commandName);
    }
}
