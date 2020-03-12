using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows.Controls;
using Jaml.Wpf.Models.ChildModels;
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
    public class GridModel : FrameworkElementModel
    {
        #region Json Properties

        /// <summary>
        /// Collection of row definitions
        /// </summary>
        [JsonPropertyName("RowDefinitions")]
        public IEnumerable<RowDefinitionModel> RowDefinitions { get; set; } = new List<RowDefinitionModel>();

        /// <summary>
        /// Collection of column definitions
        /// </summary>
        [JsonPropertyName("ColumnDefinitions")]
        public IEnumerable<ColumnDefinitionModel> ColumnDefinitions { get; set; } = new List<ColumnDefinitionModel>();

        /// <summary>
        /// Collection of children, bound to this grid
        /// </summary>
        [JsonPropertyName("Children")]
        public IEnumerable<ChildModel> Children { get; set; } = new List<ChildModel>();

        /// <summary>
        /// Grid's background
        /// </summary>
        [JsonPropertyName("Background")]
        public BackgroundModel Background { get; set; } = null;

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
            BindProperties(ref grid);

            //Bind commands
            commandProvider.BindCommands(ref grid, Commands);
        }

        /// <summary>
        /// Binds model properies from model to passed element
        /// </summary>
        /// <typeparam name="T">Children of <see cref="Grid"/></typeparam>
        /// <param name="element">Element to take properties</param>
        public new void BindProperties<T>(ref T element) where T : Grid
        {
            //todo
            base.BindProperties(ref element);

            foreach (RowDefinitionModel rowDefinitionModel in RowDefinitions)
                element.RowDefinitions.Add(rowDefinitionModel.ToRowDefinition());

            foreach (ColumnDefinitionModel columnDefinitionModel in ColumnDefinitions)
                element.ColumnDefinitions.Add(columnDefinitionModel.ToColumnDefinition());

            element.Background = PropertyParser.ParseBackground(Background);
        }
    }
}
