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
    public class GridModel : PanelModel
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

        /// <summary>
        /// Creates grid from model
        /// </summary>
        /// <typeparam name="T">Children of <see cref="Grid"/></typeparam>
        /// <param name="grid">Target grid</param>
        /// <param name="commandProvider">Command provider</param>
        /// <param name="styleProvider">Style provider</param>
        public void ToGrid<T>(ref T grid, ICommandProvider commandProvider, IStyleProvider styleProvider) where T : Grid
        {
            //Bind styles
            styleProvider.BindStyle(ref grid, StyleId);

            //Explicitly initialized properties should override styles

            //Bind properties
            BindProperties(ref grid, commandProvider, styleProvider);
        }

        /// <summary>
        /// Binds model properies from model to passed element
        /// </summary>
        /// <typeparam name="T">Children of <see cref="Grid"/></typeparam>
        /// <param name="element">Element to take properties</param>
        /// <param name="commandProvider">Command provider</param>
        /// <param name="styleProvider">Style provider</param>
        public new void BindProperties<T>(ref T element, ICommandProvider commandProvider, IStyleProvider styleProvider) where T : Grid
        {
            base.BindProperties(ref element, commandProvider, styleProvider);

            foreach (string rowDefinition in RowDefinitions)
                element.RowDefinitions.Add(PropertyParser.ParseRowDefinition(rowDefinition));

            foreach (string columnDefinition in ColumnDefinitions)
                element.ColumnDefinitions.Add(PropertyParser.ParseColumnDefinition(columnDefinition));
        }
    }
}
