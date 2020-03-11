using System.Windows.Controls;
using Jaml.Wpf.Helpers;
using Jaml.Wpf.Models.CommandModels;
using Jaml.Wpf.Models.StyleModels;
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
            mediaElement.VerticalAlignment = PropertyParser.ParseVerticalAlignment(VerticalAlignment);
            mediaElement.HorizontalAlignment = PropertyParser.ParseHorizontalAlignment(HorizontalAlignment);
            mediaElement.Source = PathsHelper.GetUriFromRelativePath(Content);
            mediaElement.LoadedBehavior = MediaState.Manual;

            foreach (ICommandModel commandModel in Commands)
                commandModel.BindCommand(ref mediaElement, commandProvider);

            IStyleModel styleModel = GetCorrespondingStyle(styleProvider);
            styleModel?.BindStyle(mediaElement);
        }
    }
}
