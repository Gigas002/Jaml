using System.Text.Json.Serialization;
using System.Windows.Controls;
using Jaml.Wpf.Models.UIElementModels;

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
        public GridModel<Grid> GridModel { get; set; } = null;

        #endregion
    }
}
