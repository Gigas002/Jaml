using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Jaml.Wpf.Helpers;
using Jaml.Wpf.Models.ChildModels;
using Jaml.Wpf.Models.UiElementModels;
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
        /// Parse the specific <see cref="UIElement"/>
        /// </summary>
        /// <typeparam name="T"><see cref="UIElement"/> and it's children</typeparam>
        /// <param name="parentGrid">Grid to which bind the element</param>
        /// <param name="uiElementModel">Model to parse and bind</param>
        /// <param name="commandProvider">Command provider</param>
        /// <param name="styleProvider">Style provider</param>
        public static void ParseUiElement<T>(Grid parentGrid, IUiElementModel uiElementModel, ICommandProvider commandProvider, IStyleProvider styleProvider)
            where T : UIElement
        {
            T element = uiElementModel.ToUiElement<T>(commandProvider, styleProvider);

            UIHelper.AddElementToGrid(parentGrid, element, uiElementModel.ParentRow, uiElementModel.ParentColumn,
                                      uiElementModel.RowSpan, uiElementModel.ColumnSpan);

            //todo temp! Grid only part
            if (typeof(T) != typeof(Grid)) return;

            var gridElementModel = uiElementModel as GridModel;
            var childGrid = element as Grid;

            //Parse and add children
            ParseChildren(childGrid, gridElementModel?.Children, commandProvider, styleProvider);
        }

        /// <summary>
        /// Todo temp
        /// </summary>
        /// <param name="parentGrid">Grid to which bind the element</param>
        /// <param name="imageModel">Model to parse and bind</param>
        /// <param name="commandProvider">Command provider</param>
        /// <param name="styleProvider">Style provider</param>
        public static void ParseAndAddImage(Grid parentGrid, ImageModel imageModel, ICommandProvider commandProvider, IStyleProvider styleProvider)
        {
            Image image = imageModel.ToImage(commandProvider, styleProvider);

            UIHelper.AddElementToGrid(parentGrid, image, imageModel.ParentRow, imageModel.ParentColumn,
                                      imageModel.RowSpan, imageModel.ColumnSpan);
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
                    ParseUiElement<Button>(parentGrid, childModel.ButtonModel, commandProvider, styleProvider);
                else if (childModel.GridModel != null)
                    ParseUiElement<Grid>(parentGrid, childModel.GridModel, commandProvider, styleProvider);
                else if (childModel.MediaElementModel != null)
                    ParseUiElement<MediaElement>(parentGrid, childModel.MediaElementModel, commandProvider, styleProvider);
                else if (childModel.ImageModel != null)
                    ParseAndAddImage(parentGrid, childModel.ImageModel, commandProvider, styleProvider);
                //ParseUIElement<MediaElement>(parentGrid, childModel.ImageModel, commandProvider);
            }

            //When all children initialized...
        }
    }
}
