using System;
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

namespace Jaml.Wpf.Models.UiElementModels
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class GridModel : UiElementModel
    {
        #region Json Properties

        [JsonPropertyName("RowDefinitions")]
        public IEnumerable<RowDefinitionModel> RowDefinitions { get; set; } = new List<RowDefinitionModel>();

        [JsonPropertyName("ColumnDefinitions")]
        public IEnumerable<ColumnDefinitionModel> ColumnDefinitions { get; set; } = new List<ColumnDefinitionModel>();

        [JsonPropertyName("Children")]
        public IEnumerable<ChildModel> Children { get; set; } = new List<ChildModel>();

        [JsonPropertyName("Background")]
        public BackgroundModel Background { get; set; } = null;

        #endregion

        public override T ToUiElement<T>(ICommandProvider commandProvider, IStyleProvider styleProvider)
        {
            Grid grid = new Grid
            {
                VerticalAlignment = PropertyParser.ParseVerticalAlignment(VerticalAlignment),
                HorizontalAlignment = PropertyParser.ParseHorizontalAlignment(HorizontalAlignment)
            };

            foreach (RowDefinitionModel rowDefinitionModel in RowDefinitions)
                grid.RowDefinitions.Add(rowDefinitionModel.ToRowDefinition());

            foreach (ColumnDefinitionModel columnDefinitionModel in ColumnDefinitions)
                grid.ColumnDefinitions.Add(columnDefinitionModel.ToColumnDefinition());

            grid.Background = PropertyParser.ParseBackground(Background);

            foreach (CommandModel commandModel in Commands) commandModel.BindCommand(grid, commandProvider);

            IStyleModel styleModel = GetCorrespondingStyle(styleProvider);
            styleModel?.BindStyle(grid);

            return (T) Convert.ChangeType(grid, typeof(T));
        }
    }
}
