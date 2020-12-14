using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows.Controls;
using Jaml.Wpf.Exceptions;
using Jaml.Wpf.Models.StyleModels;
using Jaml.Wpf.Parsers;
using Jaml.Wpf.Providers.CommandProviders;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace Jaml.Wpf.Models.UIElementModels
{
    // ReSharper disable once ClassNeverInstantiated.Global

    /// <summary>
    /// Model of Grid
    /// </summary>
    /// <typeparam name="T">Children of <see cref="Grid"/></typeparam>
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
        public override T ToUIElement(ICommandProvider commandProvider = null, IList<StyleModel> styleModels = null)
        {
            T element = base.ToUIElement(commandProvider, styleModels);

            BindProperties(element);

            return element;
        }

        /// <inheritdoc />
        public new void BindProperties(T element, ICommandProvider commandProvider = null,
                                       IList<StyleModel> styleModels = null)
        {
            if (element is null) throw new UIException(nameof(element));

            foreach (string rowDefinition in RowDefinitions)
                element.RowDefinitions.Add(PropertyParser.ParseRowDefinition(rowDefinition));

            foreach (string columnDefinition in ColumnDefinitions)
                element.ColumnDefinitions.Add(PropertyParser.ParseColumnDefinition(columnDefinition));
        }
    }
}
