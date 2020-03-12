using System.Text.Json.Serialization;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Jaml.Wpf.Helpers;
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
        #region Properties

        /// <summary>
        /// Element's content
        /// </summary>
        [JsonPropertyName("Content")]
        public string Content { get; set; } = null;

        #endregion

        /// <summary>
        /// Creates image from model
        /// </summary>
        /// <typeparam name="T">Children of <see cref="Image"/></typeparam>
        /// <param name="image">Target image</param>
        /// <param name="commandProvider">Command provider</param>
        /// <param name="styleProvider">Style provider</param>
        public void ToImage<T>(ref T image, ICommandProvider commandProvider, IStyleProvider styleProvider) where T : Image
        {
            //Bind styles
            styleProvider.BindStyle(ref image, StyleId);

            //Explicitly initialized properties should override styles

            //Bind properties
            BindProperties(ref image);

            //Bind commands
            commandProvider.BindCommands(ref image, Commands);
        }

        /// <summary>
        /// Binds model properies from model to passed element
        /// </summary>
        /// <typeparam name="T">Children of <see cref="Image"/></typeparam>
        /// <param name="element">Element to take properties</param>
        public new void BindProperties<T>(ref T element) where T : Image
        {
            //todo move this method up, to UIElement or FrameworkElement
            base.BindProperties(ref element);
            if (!string.IsNullOrWhiteSpace(Content))
                element.Source = new BitmapImage(PathsHelper.GetUriFromRelativePath(Content));
        }
    }
}
