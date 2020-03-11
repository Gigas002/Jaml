using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Jaml.Wpf.Helpers;
using Jaml.Wpf.Models.CommandModels;
using Jaml.Wpf.Models.StyleModels;
using Jaml.Wpf.Parsers;
using Jaml.Wpf.Providers.CommandProvider;
using Jaml.Wpf.Providers.StyleProvider;

// ReSharper disable ClassNeverInstantiated.Global

namespace Jaml.Wpf.Models.UIElementModels
{
    /// <summary>
    /// Image model
    /// </summary>
    public class ImageModel : FrameworkElementModel
    {
        /// <summary>
        /// Creates image from model
        /// </summary>
        /// <typeparam name="T">Children of <see cref="Image"/></typeparam>
        /// <param name="image">Target image</param>
        /// <param name="commandProvider">Command provider</param>
        /// <param name="styleProvider">Style provider</param>
        public void ToImage<T>(ref T image, ICommandProvider commandProvider, IStyleProvider styleProvider) where T : Image
        {
            image.VerticalAlignment = PropertyParser.ParseVerticalAlignment(VerticalAlignment);
            image.HorizontalAlignment = PropertyParser.ParseHorizontalAlignment(HorizontalAlignment);
            image.Source = new BitmapImage(PathsHelper.GetUriFromRelativePath(Content));

            foreach (ICommandModel commandModel in Commands)
                commandModel.BindCommand(ref image, commandProvider);

            IStyleModel styleModel = GetCorrespondingStyle(styleProvider);
            styleModel?.BindStyle(image);
        }
    }
}
