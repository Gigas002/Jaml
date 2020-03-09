using System.Windows;
using Jaml.Wpf.Providers.CommandProvider;

// ReSharper disable UnusedMemberInSuper.Global

namespace Jaml.Wpf.Models.CommandModels
{
    /// <summary>
    /// Interface for creating your own CommandModels
    /// </summary>
    public interface ICommandModel
    {
        /// <summary>
        /// Event name
        /// </summary>
        public string Event { get; }

        /// <summary>
        /// Method to call
        /// </summary>
        public string Method { get; }

        /// <summary>
        /// Arguments, passed to the method
        /// </summary>
        public string Args { get; }

        /// <summary>
        /// Binds command to passed <see cref="UIElement"/>
        /// </summary>
        /// <param name="element">Target element to bind the command</param>
        /// <param name="commandProvider">Provider of commands</param>
        public void BindCommand(UIElement element, ICommandProvider commandProvider);
    }
}
