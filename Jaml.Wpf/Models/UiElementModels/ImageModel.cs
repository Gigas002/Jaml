using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Jaml.Wpf.Helpers;
using Jaml.Wpf.Models.CommandModels;
using Jaml.Wpf.Parsers;
using Jaml.Wpf.Providers.CommandProvider;
using Jaml.Wpf.Providers.StyleProvider;

// ReSharper disable ClassNeverInstantiated.Global

namespace Jaml.Wpf.Models.UiElementModels
{
    public class ImageModel : UiElementModel
    {
        public Image ToImage(ICommandProvider commandProvider)
        {
            Image image = new Image
            {
                VerticalAlignment = PropertyParser.ParseVerticalAlignment(VerticalAlignment),
                HorizontalAlignment = PropertyParser.ParseHorizontalAlignment(HorizontalAlignment),
                Source = new BitmapImage(PathsHelper.GetUriFromRelativePath(Content))
            };

            foreach (CommandModel commandModel in Commands) commandModel.BindCommand(image, commandProvider);

            return image;
        }

        public override T ToUiElement<T>(ICommandProvider commandProvider, IStyleProvider styleProvider)
        {
            throw new NotImplementedException();

            //Image image = new Image
            //{
            //    VerticalAlignment = ModelPropertiesParser.ParseVerticalAlignment(VerticalAlignment),
            //    HorizontalAlignment = ModelPropertiesParser.ParseHorizontalAlignment(HorizontalAlignment),
            //    Source = new BitmapImage(PathsHelper.GetUriFromRelativePath(Content))
            //};

            ////throws an exception
            //return (T) Convert.ChangeType(image, typeof(T));
        }
    }
}
