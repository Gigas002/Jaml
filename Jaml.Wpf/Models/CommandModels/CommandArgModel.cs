using System.Text.Json.Serialization;

// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Jaml.Wpf.Models.CommandModels
{
    /// <summary>
    /// Model of command argument
    /// </summary>
    public class CommandArgModel : ICommandArgModel
    {
        /// <inheritdoc />
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        /// <inheritdoc />
        [JsonPropertyName("Value")]
        public string Value { get; set; }
    }
}
