

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
    }
}
