using System.Text.Json.Serialization;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace Jaml.Wpf.Models.CommandModels
{
    // ReSharper disable once ClassNeverInstantiated.Global

    /// <summary>
    /// Model of commands
    /// </summary>
    public class CommandModel : ICommandModel
    {
        #region Json Properties

        /// <inheritdoc />
        [JsonPropertyName("Event")]
        public string Event { get; set; } = null;

        /// <inheritdoc />
        [JsonPropertyName("Method")]
        public string Method { get; set; } = null;

        /// <inheritdoc />
        [JsonPropertyName("Args")]
        public string Args { get; set; } = null;

        #endregion
    }
}
