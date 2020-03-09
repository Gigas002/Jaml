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
    public class UiElementModel : IUiElementModel
    {
        #region Json Properties

        [JsonPropertyName("Name")]
        public string Name { get; set; } = null;

        [JsonPropertyName("VerticalAlignment")]
        public string VerticalAlignment { get; set; } = null;

        [JsonPropertyName("HorizontalAlignment")]
        public string HorizontalAlignment { get; set; } = null;

        [JsonPropertyName("Content")]
        public string Content { get; set; } = null;

        [JsonPropertyName("StyleId")]
        public int StyleId { get; set; } = -1;

        [JsonPropertyName("ParentRow")]
        public int ParentRow { get; set; } = 0;

        [JsonPropertyName("ParentColumn")]
        public int ParentColumn { get; set; } = 0;

        [JsonPropertyName("RowSpan")]
        public int RowSpan { get; set; } = 1;

        [JsonPropertyName("ColumnSpan")]
        public int ColumnSpan { get; set; } = 1;

        [JsonPropertyName("Commands")]
        public IEnumerable<CommandModel> Commands { get; set; } = new List<CommandModel>();

        #endregion

        public virtual T ToUiElement<T>(ICommandProvider commandProvider, IStyleProvider styleProvider) where T : UIElement => null;

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
