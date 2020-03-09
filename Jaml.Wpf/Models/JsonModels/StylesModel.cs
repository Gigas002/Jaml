using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jaml.Wpf.Models.StyleModels;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace Jaml.Wpf.Models.JsonModels
{
    // ReSharper disable once ClassCanBeSealed.Global
    public class StylesModel : JsonModel
    {
        #region Json Properties

        [JsonPropertyName("Styles")]
        public IEnumerable<StyleModel> StyleModels { get; set; } = null;

        #endregion
    }
}
