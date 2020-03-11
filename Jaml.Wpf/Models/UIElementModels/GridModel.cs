using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows.Controls;
using Jaml.Wpf.Models.ChildModels;
using Jaml.Wpf.Models.CommandModels;
using Jaml.Wpf.Models.StyleModels;
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
            grid.VerticalAlignment = PropertyParser.ParseVerticalAlignment(VerticalAlignment);
            grid.HorizontalAlignment = PropertyParser.ParseHorizontalAlignment(HorizontalAlignment);

            foreach (RowDefinitionModel rowDefinitionModel in RowDefinitions)
                grid.RowDefinitions.Add(rowDefinitionModel.ToRowDefinition());

            foreach (ColumnDefinitionModel columnDefinitionModel in ColumnDefinitions)
                grid.ColumnDefinitions.Add(columnDefinitionModel.ToColumnDefinition());

            grid.Background = PropertyParser.ParseBackground(Background);

            foreach (ICommandModel commandModel in Commands)
                commandModel.BindCommand(ref grid, commandProvider);

            IStyleModel styleModel = GetCorrespondingStyle(styleProvider);
            styleModel?.BindStyle(ref grid);
        }
    }
}
