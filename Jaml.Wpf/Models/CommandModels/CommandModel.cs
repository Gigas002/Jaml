using System.Collections.Generic;
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
        public string EventName { get; set; } = null;

        /// <inheritdoc />
        [JsonPropertyName("Method")]
        public string Method { get; set; } = null;

        /// <inheritdoc />
        [JsonPropertyName("Args")]
        public IEnumerable<CommandArgModel> Args { get; set; } = null;

        #endregion
    }
}
