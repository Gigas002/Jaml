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
    public static class PageParser
    {
        public static void ParseUiElement<T>(Grid parentGrid, IUiElementModel uiElementModel, ICommandProvider commandProvider, IStyleProvider styleProvider)
            where T : UIElement
        {
            T element = uiElementModel.ToUiElement<T>(commandProvider, styleProvider);

            UIHelper.AddElementToGrid(parentGrid, element, uiElementModel.ParentRow, uiElementModel.ParentColumn,
                                      uiElementModel.RowSpan, uiElementModel.ColumnSpan);

            //todo temp!
            if (typeof(T) != typeof(Grid)) return;

            var gridElementModel = uiElementModel as GridModel;
            var childGrid = element as Grid;

            //Parse and add children
            ParseChildren(childGrid, gridElementModel?.Children, commandProvider, styleProvider);
        }

        public static void ParseAndAddImage(Grid parentGrid, ImageModel imageModel, ICommandProvider commandProvider)
        {
            Image image = imageModel.ToImage(commandProvider);

            UIHelper.AddElementToGrid(parentGrid, image, imageModel.ParentRow, imageModel.ParentColumn,
                                      imageModel.RowSpan, imageModel.ColumnSpan);
        }

        public static void ParseChildren(Grid parentGrid, IEnumerable<ChildModel> children, ICommandProvider commandProvider, IStyleProvider styleProvider)
        {
            //Initialize all children
            foreach (ChildModel childModel in children)
            {
                //That's pretty ugly...

                if (childModel.ButtonModel != null)
                    ParseUiElement<Button>(parentGrid, childModel.ButtonModel, commandProvider, styleProvider);
                else if (childModel.GridModel != null)
                    ParseUiElement<Grid>(parentGrid, childModel.GridModel, commandProvider, styleProvider);
                else if (childModel.MediaElementModel != null)
                    ParseUiElement<MediaElement>(parentGrid, childModel.MediaElementModel, commandProvider, styleProvider);
                else if (childModel.ImageModel != null)
                    ParseAndAddImage(parentGrid, childModel.ImageModel, commandProvider);
                //ParseUIElement<MediaElement>(parentGrid, childModel.ImageModel, commandProvider);
            }

            //When all children initialized...
        }
    }
}
