using System.Collections.Generic;
using System.Windows.Controls;
using Jaml.Wpf.Helpers;
using Jaml.Wpf.Models.ChildModels;
using Jaml.Wpf.Models.UIElementModels;
using Jaml.Wpf.Providers.CommandProvider;
using Jaml.Wpf.Providers.StyleProvider;

// ReSharper disable MemberCanBePrivate.Global

namespace Jaml.Wpf.Parsers
{
    /// <summary>
    /// Contains static method to parse different elements of the page
    /// </summary>
    public static class PageParser
    {
        /// <summary>
        /// Parses and adds an element to the grid
        /// </summary>
        /// <param name="parentGrid">Grid to which bind the element</param>
        /// <param name="imageModel">Model to parse and bind</param>
        /// <param name="commandProvider">Command provider</param>
        /// <param name="styleProvider">Style provider</param>
        public static void ParseAndAddImage(Grid parentGrid, ImageModel imageModel, ICommandProvider commandProvider, IStyleProvider styleProvider)
        {
            Image image = new Image();
            imageModel.ToImage(ref image, commandProvider, styleProvider);

            UIHelper.AddElementToGrid(parentGrid, image, imageModel.ParentRow, imageModel.ParentColumn,
                                      imageModel.RowSpan, imageModel.ColumnSpan);
        }

        /// <summary>
        /// Parses and adds an element to the grid
        /// </summary>
        /// <param name="parentGrid">Grid to which bind the element</param>
        /// <param name="buttonModel">Model to parse and bind</param>
        /// <param name="commandProvider">Command provider</param>
        /// <param name="styleProvider">Style provider</param>
        public static void ParseAndAddButton(Grid parentGrid, ButtonModel buttonModel, ICommandProvider commandProvider,
                                             IStyleProvider styleProvider)
        {
            Button button = new Button();
            buttonModel.ToButton(ref button, commandProvider, styleProvider);
            UIHelper.AddElementToGrid(parentGrid, button, buttonModel.ParentRow, buttonModel.ParentColumn,
                                      buttonModel.RowSpan, buttonModel.ColumnSpan);
        }

        /// <summary>
        /// Parses and adds an element to the grid
        /// </summary>
        /// <param name="parentGrid">Grid to which bind the element</param>
        /// <param name="mediaElementModel">Model to parse and bind</param>
        /// <param name="commandProvider">Command provider</param>
        /// <param name="styleProvider">Style provider</param>
        public static void ParseAndAddMediaElement(Grid parentGrid, MediaElementModel mediaElementModel,
                                                   ICommandProvider commandProvider, IStyleProvider styleProvider)
        {
            MediaElement mediaElement = new MediaElement();
            mediaElementModel.ToMediaElement(ref mediaElement, commandProvider, styleProvider);
            UIHelper.AddElementToGrid(parentGrid, mediaElement, mediaElementModel.ParentRow,
                                      mediaElementModel.ParentColumn, mediaElementModel.RowSpan,
                                      mediaElementModel.ColumnSpan);
        }

        /// <summary>
        /// Parses and adds an element to the grid
        /// </summary>
        /// <param name="parentGrid">Grid to which bind the element</param>
        /// <param name="gridModel">Model to parse and bind</param>
        /// <param name="commandProvider">Command provider</param>
        /// <param name="styleProvider">Style provider</param>
        public static void ParseAndAddGrid(Grid parentGrid, GridModel gridModel, ICommandProvider commandProvider, IStyleProvider styleProvider)
        {
            Grid grid = new Grid();
            gridModel.ToGrid(ref grid, commandProvider, styleProvider);

            UIHelper.AddElementToGrid(parentGrid, grid, gridModel.ParentRow, gridModel.ParentColumn,
                                      gridModel.RowSpan, gridModel.ColumnSpan);

            //Parse and add children
            ParseChildren(grid, gridModel.Children, commandProvider, styleProvider);
        }

        /// <summary>
        /// Parses all children of the grid
        /// </summary>
        /// <param name="parentGrid">Grid, to which children are bound</param>
        /// <param name="children">Collection of grid's child controls</param>
        /// <param name="commandProvider">Command provider</param>
        /// <param name="styleProvider">Style provider</param>
        public static void ParseChildren(Grid parentGrid, IEnumerable<ChildModel> children, ICommandProvider commandProvider, IStyleProvider styleProvider)
        {
            //Initialize all children
            foreach (ChildModel childModel in children)
            {
                //Todo that's pretty ugly...

                if (childModel.ButtonModel != null)
                    ParseAndAddButton(parentGrid, childModel.ButtonModel, commandProvider, styleProvider);
                else if (childModel.GridModel != null)
                    ParseAndAddGrid(parentGrid, childModel.GridModel, commandProvider, styleProvider);
                else if (childModel.MediaElementModel != null)
                    ParseAndAddMediaElement(parentGrid, childModel.MediaElementModel, commandProvider, styleProvider);
                else if (childModel.ImageModel != null)
                    ParseAndAddImage(parentGrid, childModel.ImageModel, commandProvider, styleProvider);
            }

            //When all children initialized...
        }
    }
}
