using System.Text.Json.Serialization;
using Jaml.Wpf.Models.UIElementModels;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace Jaml.Wpf.Models.ChildModels
{
    // ReSharper disable once ClassNeverInstantiated.Global

    /// <summary>
    /// Model of child elements
    /// </summary>
    public class ChildModel
    {
        #region Json Properties

        /// <summary>
        /// Media element. Can be video or audio file
        /// </summary>
        [JsonPropertyName("MediaElement")]
        public MediaElementModel MediaElementModel { get; set; } = null;

        /// <summary>
        /// Non-animated image
        /// </summary>
        [JsonPropertyName("Image")]
        public ImageModel ImageModel { get; set; } = null;

        /// <summary>
        /// Button
        /// </summary>
        [JsonPropertyName("Button")]
        public ButtonModel ButtonModel { get; set; } = null;

        /// <summary>
        /// Grid
        /// </summary>
        [JsonPropertyName("Grid")]
        public GridModel GridModel { get; set; } = null;

        #endregion
    }
}
