using System;
using System.Collections.Generic;
using System.Windows;
using Jaml.Wpf.Models.CommandModels;

namespace Jaml.Wpf.Providers.CommandProvider
{
    /// <summary>
    /// Base interface for command operations
    /// </summary>
    public interface ICommandProvider
    {
        /// <summary>
        /// Dictionary of commands. Key is name, and Value is delegate to run
        /// </summary>
        public Dictionary<string, Delegate> Commands { get; }

        /// <summary>
        /// Registers all commands from dictionary
        /// </summary>
        /// <param name="commands">Dictionary to register</param>
        public void RegisterCommands(Dictionary<string, Delegate> commands);

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
        /// <param name="command">Delegate to run</param>
        public void RegisterCommand(string commandName, Delegate command);

        /// <summary>
        /// Delete the specified command from dictionary
        /// </summary>
        /// <param name="commandName">Comamnd name to delete</param>
        public void UnregisterCommand(string commandName);

        /// <summary>
        /// Adds additional delegate to already existent command
        /// </summary>
        /// <param name="commandName">Command name, to which delegate will be added</param>
        /// <param name="delegateToAdd">Delegate to add</param>
        public void AddToExistentCommand(string commandName, Delegate delegateToAdd);

        /// <summary>
        /// Removes the delegate from alreade existent command
        /// </summary>
        /// <param name="commandName">Name of command, from which delegate will be removed</param>
        /// <param name="delegateToRemove">Delegate to remove</param>
        public void RemoveFromExistentCommand(string commandName, Delegate delegateToRemove);

        /// <summary>
        /// Starts the command
        /// </summary>
        /// <param name="commandName">Name of command to start</param>
        /// <param name="sender">Sender of command</param>
        /// <param name="args">Arguments for command</param>
        public void RunCommand(string commandName, object sender = null, string args = null);

        /// <summary>
        /// Gets command by name
        /// </summary>
        /// <param name="commandName">Name of command to get</param>
        /// <returns>Command's <see cref="Delegate"/></returns>
        public Delegate GetCommand(string commandName);

        /// <summary>
        /// Binds command to passed element
        /// </summary>
        /// <typeparam name="T">Children of <see cref="UIElement"/></typeparam>
        /// <param name="element">Target element to bind the command</param>
        /// <param name="commandModel">Model of command for element</param>
        public void BindCommand<T>(ref T element, ICommandModel commandModel) where T : UIElement;

        /// <summary>
        /// Binds commands to passed element
        /// </summary>
        /// <typeparam name="T">Children of <see cref="UIElement"/></typeparam>
        /// <param name="element">Target element to bind the command</param>
        /// <param name="commandModels">Collection of models of command for element</param>
        public void BindCommands<T>(ref T element, IEnumerable<ICommandModel> commandModels) where T : UIElement;
    }
}
