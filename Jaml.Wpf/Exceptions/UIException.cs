using System;

// ReSharper disable InconsistentNaming

namespace Jaml.Wpf.Exceptions
{
    /// <inheritdoc />
    public class UIException : Exception
    {
        /// <inheritdoc />
        public UIException(string message) : base(message) { }

        /// <inheritdoc />
        public UIException(string message, Exception innerException) : base(message, innerException) { }

        /// <inheritdoc />
        public UIException() { }
    }
}
