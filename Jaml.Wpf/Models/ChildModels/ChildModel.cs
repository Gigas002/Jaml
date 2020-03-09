using System.Text.Json.Serialization;
using Jaml.Wpf.Models.UiElementModels;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace Jaml.Wpf.Models.ChildModels
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class ChildModel
    {
        #region Json Properties

        [JsonPropertyName("MediaElement")]
        public MediaElementModel MediaElementModel { get; set; } = null;

        [JsonPropertyName("Image")]
        public ImageModel ImageModel { get; set; } = null;

        [JsonPropertyName("Button")]
        public ButtonModel ButtonModel { get; set; } = null;

        [JsonPropertyName("Grid")]
        public GridModel GridModel { get; set; } = null;

        #endregion
    }
}
