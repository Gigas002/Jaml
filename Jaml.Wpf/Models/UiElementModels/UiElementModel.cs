using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Windows;
using Jaml.Wpf.Models.CommandModels;
using Jaml.Wpf.Models.StyleModels;
using Jaml.Wpf.Providers.CommandProvider;
using Jaml.Wpf.Providers.StyleProvider;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace Jaml.Wpf.Models.UiElementModels
{
    /// <summary>
    /// Base class, that implements <see cref="IUiElementModel"/>
    /// </summary>
    public class UiElementModel : IUiElementModel
    {
        #region Json Properties

        /// <inheritdoc />
        [JsonPropertyName("Name")]
        public string Name { get; set; } = null;

        /// <inheritdoc />
        [JsonPropertyName("VerticalAlignment")]
        public string VerticalAlignment { get; set; } = null;

        /// <inheritdoc />
        [JsonPropertyName("HorizontalAlignment")]
        public string HorizontalAlignment { get; set; } = null;

        /// <inheritdoc />
        [JsonPropertyName("Content")]
        public string Content { get; set; } = null;

        /// <inheritdoc />
        [JsonPropertyName("StyleId")]
        public int StyleId { get; set; } = -1;

        /// <inheritdoc />
        [JsonPropertyName("ParentRow")]
        public int ParentRow { get; set; } = 0;

        /// <inheritdoc />
        [JsonPropertyName("ParentColumn")]
        public int ParentColumn { get; set; } = 0;

        /// <inheritdoc />
        [JsonPropertyName("RowSpan")]
        public int RowSpan { get; set; } = 1;

        /// <inheritdoc />
        [JsonPropertyName("ColumnSpan")]
        public int ColumnSpan { get; set; } = 1;

        /// <inheritdoc />
        [JsonPropertyName("Commands")]
        public IEnumerable<CommandModel> Commands { get; set; } = new List<CommandModel>();

        #endregion

        /// <inheritdoc />
        public virtual T ToUiElement<T>(ICommandProvider commandProvider, IStyleProvider styleProvider) where T : UIElement => null;

        /// <inheritdoc />
        public IStyleModel GetCorrespondingStyle(IStyleProvider styleProvider)
        {
            if (!styleProvider.Styles.Any()) return null;

            foreach ((int styleId, IStyleModel styleModel) in styleProvider.Styles)
                if (styleId == StyleId)
                    return styleModel;

            return null;
        }
    }
}
