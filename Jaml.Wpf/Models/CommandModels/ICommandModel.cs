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
        /// Binds command to passed element
        /// </summary>
        /// <typeparam name="T">Children of <see cref="UIElement"/></typeparam>
        /// <param name="element">Target element to bind the command</param>
        /// <param name="commandProvider">Provider of commands</param>
        public void BindCommand<T>(ref T element, ICommandProvider commandProvider) where T : UIElement;
    }
}
