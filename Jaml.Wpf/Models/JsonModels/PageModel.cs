using System.Text.Json.Serialization;
using Jaml.Wpf.Models.UiElementModels;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace Jaml.Wpf.Models.JsonModels
{
    // ReSharper disable once ClassNeverInstantiated.Global

    /// <summary>
    /// Any page in application
    /// </summary>
    public class PageModel : JsonModel
    {
        #region Json Properties

        /// <summary>
        /// Json's Page element
        /// </summary>
        [JsonPropertyName("Page")]
        public PageModel Page { get; set; } = null;

        /// <summary>
        /// Json's Grid element
        /// </summary>
        [JsonPropertyName("Grid")]
        public GridModel GridModel { get; set; } = null;

        #endregion
    }
}
