using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jaml.Wpf.Models.StyleModels;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace Jaml.Wpf.Models.JsonModels
{
    // ReSharper disable once ClassCanBeSealed.Global

    /// <summary>
    /// Defines list of styles for app's controls
    /// </summary>
    public class StylesModel : JsonModel
    {
        #region Json Properties

        /// <summary>
        /// Collection of styles
        /// </summary>
        [JsonPropertyName("Styles")]
        public IEnumerable<StyleModel> StyleModels { get; set; } = null;

        #endregion
    }
}
