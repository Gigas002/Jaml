using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows.Controls;
using Jaml.Wpf.Parsers;
using Jaml.Wpf.Providers.CommandProvider;
using Jaml.Wpf.Providers.StyleProvider;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace Jaml.Wpf.Models.UIElementModels
{
    // ReSharper disable once ClassNeverInstantiated.Global

    /// <summary>
    /// Model of Grid
    /// </summary>
    public class GridModel<T> : PanelModel<T>, IUIElementModel<T> where T : Grid, new()
    {
        #region Json Properties

        /// <summary>
        /// Collection of row definitions
        /// </summary>
        [JsonPropertyName("RowDefinitions")]
        public IEnumerable<string> RowDefinitions { get; set; } = new List<string>();

        /// <summary>
        /// Collection of column definitions
        /// </summary>
        [JsonPropertyName("ColumnDefinitions")]
        public IEnumerable<string> ColumnDefinitions { get; set; } = new List<string>();

        #endregion

        /// <inheritdoc />
        public override T ToUIElement(ICommandProvider commandProvider, IStyleProvider styleProvider)
        {
            T element = base.ToUIElement(commandProvider, styleProvider);

            BindProperties(element, null, null);

            return element;
        }

        /// <inheritdoc />
        public new void BindProperties(T element, ICommandProvider commandProvider, IStyleProvider styleProvider)
        {
            foreach (string rowDefinition in RowDefinitions)
                element.RowDefinitions.Add(PropertyParser.ParseRowDefinition(rowDefinition));

            foreach (string columnDefinition in ColumnDefinitions)
                element.ColumnDefinitions.Add(PropertyParser.ParseColumnDefinition(columnDefinition));
        }
    }
}
