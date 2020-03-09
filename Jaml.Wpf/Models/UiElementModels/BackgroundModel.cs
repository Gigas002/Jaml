using System.Text.Json.Serialization;

// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Jaml.Wpf.Models.UiElementModels
{
    /// <summary>
    /// todo
    /// </summary>
    public class BackgroundModel
    {
        #region Json Properties

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("IsImage")]
        public bool IsImage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("Value")]
        public string Value { get; set; }

        #endregion
    }
}
