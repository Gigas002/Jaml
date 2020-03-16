using System.Text.Json.Serialization;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Jaml.Wpf.Helpers;
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
        [JsonPropertyName("Source")]
        public string Source { get; set; } = string.Empty;

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
            //Bind properties
            BindProperties(ref image, commandProvider, styleProvider);
        }

        /// <summary>
        /// Binds model properies from model to passed element
        /// </summary>
        /// <typeparam name="T">Children of <see cref="Image"/></typeparam>
        /// <param name="element">Element to take properties</param>
        /// <param name="commandProvider">Command provider</param>
        /// <param name="styleProvider">Style provider</param>
        public new void BindProperties<T>(ref T element, ICommandProvider commandProvider, IStyleProvider styleProvider) where T : Image
        {
            base.BindProperties(ref element, commandProvider, styleProvider);

            if (!string.IsNullOrWhiteSpace(Source))
                element.Source = new BitmapImage(PathsHelper.GetUriFromRelativePath(Source));
        }
    }
}
