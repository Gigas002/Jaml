using System.Text.Json.Serialization;

// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Jaml.Wpf.Models.UiElementModels
{
    //todo
    public class BackgroundModel
    {
        #region Json Properties

        [JsonPropertyName("IsImage")]
        public bool IsImage { get; set; }

        [JsonPropertyName("Value")]
        public string Value { get; set; }

        #endregion
    }
}
