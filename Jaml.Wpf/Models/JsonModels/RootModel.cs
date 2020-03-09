using System.Text.Json.Serialization;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace Jaml.Wpf.Models.JsonModels
{
    /// <summary>
    /// Root of the application
    /// </summary>
    public class RootModel : JsonModel
    {
        #region Json Properties

        /// <summary>
        /// Json's Root element
        /// </summary>
        [JsonPropertyName("Root")]
        public RootModel Root { get; set; } = null;

        /// <summary>
        /// First loaded by Root page
        /// </summary>
        [JsonPropertyName("FirstPage")]
        public string FirstPage { get; set; } = null;

        /// <summary>
        /// Json's Styles element
        /// </summary>
        [JsonPropertyName("Styles")]
        public string Styles { get; set; } = null;

        #endregion
    }
}
