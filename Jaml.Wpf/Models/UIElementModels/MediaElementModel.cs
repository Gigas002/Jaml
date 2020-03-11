using System.Windows.Controls;
using Jaml.Wpf.Helpers;
using Jaml.Wpf.Parsers;
using Jaml.Wpf.Providers.CommandProvider;
using Jaml.Wpf.Providers.StyleProvider;

namespace Jaml.Wpf.Models.UIElementModels
{
    // ReSharper disable once ClassNeverInstantiated.Global

    /// <summary>
    /// Model of media elements, like video or audio
    /// </summary>
    public class MediaElementModel : FrameworkElementModel
    {
        /// <summary>
        /// Creates media element from model
        /// </summary>
        /// <typeparam name="T">Children of <see cref="MediaElement"/></typeparam>
        /// <param name="mediaElement">Target media element</param>
        /// <param name="commandProvider">Command provider</param>
        /// <param name="styleProvider">Style provider</param>
        public void ToMediaElement<T>(ref T mediaElement, ICommandProvider commandProvider,
                                      IStyleProvider styleProvider) where T : MediaElement
        {
            //Bind styles
            styleProvider.BindStyle(ref mediaElement, StyleId);

            //Explicitly initialized properties should override styles

            //Bind properties
            BindProperties(ref mediaElement);

            //Bind commands
            commandProvider.BindCommands(ref mediaElement, Commands);
        }

        /// <summary>
        /// Binds model properies from model to passed element
        /// </summary>
        /// <typeparam name="T">Children of <see cref="MediaElement"/></typeparam>
        /// <param name="element">Element to take properties</param>
        public void BindProperties<T>(ref T element) where T : MediaElement
        {
            //todo move this method up, to UIElement or FrameworkElement
            if (!string.IsNullOrWhiteSpace(Content))
                element.Source = PathsHelper.GetUriFromRelativePath(Content);
            if (!string.IsNullOrWhiteSpace(VerticalAlignment))
                element.VerticalAlignment = PropertyParser.ParseVerticalAlignment(VerticalAlignment);
            if (!string.IsNullOrWhiteSpace(HorizontalAlignment))
                element.HorizontalAlignment = PropertyParser.ParseHorizontalAlignment(HorizontalAlignment);
            element.LoadedBehavior = MediaState.Manual;
        }
    }
}
