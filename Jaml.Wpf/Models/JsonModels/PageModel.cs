using System.Text.Json.Serialization;
using Jaml.Wpf.Models.UiElementModels;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace Jaml.Wpf.Models.JsonModels
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class PageModel : JsonModel
    {
        #region Json Properties

        [JsonPropertyName("Page")]
        public PageModel Page { get; set; } = null;

        [JsonPropertyName("Grid")]
        public GridModel GridModel { get; set; } = null;

        #endregion
    }
}
