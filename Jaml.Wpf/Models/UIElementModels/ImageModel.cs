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
    /// <typeparam name="T">Children of <see cref="Image"/></typeparam>
    public class ImageModel<T> : FrameworkElementModel<T>, IUIElementModel<T> where T : Image, new()
    {
        #region Properties

        /// <summary>
        /// Element's content
        /// </summary>
        [JsonPropertyName("Source")]
        public string Source { get; set; } = string.Empty;

        #endregion

        /// <inheritdoc />
        public override T ToUIElement(ICommandProvider commandProvider, IStyleProvider styleProvider)
        {
            T element = base.ToUIElement(commandProvider, styleProvider);

            BindProperties(element, null, null);

            return element;
        }

        /// <inheritdoc />
        public new void BindProperties(T element, ICommandProvider commandProvider, IStyleProvider styleProvider)
        {
            if (!string.IsNullOrWhiteSpace(Source))
                element.Source = new BitmapImage(PathsHelper.GetUriFromRelativePath(Source));
        }
    }
}
