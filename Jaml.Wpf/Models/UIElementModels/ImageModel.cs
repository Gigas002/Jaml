using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Jaml.Wpf.Helpers;
using Jaml.Wpf.Models.StyleModels;
using Jaml.Wpf.Providers.CommandProviders;

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
        public override T ToUIElement(ICommandProvider commandProvider = null, IList<StyleModel> styleModels = null)
        {
            T element = base.ToUIElement(commandProvider, styleModels);

            BindProperties(element);

            return element;
        }

        /// <inheritdoc />
        public new void BindProperties(T element, ICommandProvider commandProvider = null,
                                       IList<StyleModel> styleModels = null)
        {
            if (!string.IsNullOrWhiteSpace(Source))
                element.Source = new BitmapImage(PathsHelper.GetUriFromRelativePath(Source));
        }
    }
}
