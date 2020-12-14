using System;

// ReSharper disable InconsistentNaming

namespace Jaml.Wpf.Exceptions
{
    /// <inheritdoc />
    public class CommandException : Exception
    {
        /// <inheritdoc />
        public CommandException(string message) : base(message) { }

        /// <inheritdoc />
        public CommandException(string message, Exception innerException) : base(message, innerException) { }

        /// <inheritdoc />
        public CommandException() { }
    }
}
