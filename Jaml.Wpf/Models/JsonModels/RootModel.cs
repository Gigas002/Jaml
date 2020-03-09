using System.Text.Json.Serialization;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace Jaml.Wpf.Models.JsonModels
{
    public class RootModel : JsonModel
    {
        #region Json Properties

        [JsonPropertyName("Root")]
        public RootModel Root { get; set; } = null;

        [JsonPropertyName("FirstPage")]
        public string FirstPage { get; set; } = null;

        [JsonPropertyName("Styles")]
        public string Styles { get; set; } = null;

        #endregion
    }
}
