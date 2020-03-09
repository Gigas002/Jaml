using System;
using System.Windows.Controls;
using Jaml.Wpf.Helpers;
using Jaml.Wpf.Models.CommandModels;
using Jaml.Wpf.Models.StyleModels;
using Jaml.Wpf.Parsers;
using Jaml.Wpf.Providers.CommandProvider;
using Jaml.Wpf.Providers.StyleProvider;

namespace Jaml.Wpf.Models.UiElementModels
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class MediaElementModel : UiElementModel
    {
        public override T ToUiElement<T>(ICommandProvider commandProvider, IStyleProvider styleProvider)
        {
            MediaElement mediaElement = new MediaElement
            {
                VerticalAlignment = PropertyParser.ParseVerticalAlignment(VerticalAlignment),
                HorizontalAlignment = PropertyParser.ParseHorizontalAlignment(HorizontalAlignment),
                Source = PathsHelper.GetUriFromRelativePath(Content),
                LoadedBehavior = MediaState.Manual
            };

            foreach (CommandModel commandModel in Commands) commandModel.BindCommand(mediaElement, commandProvider);

            IStyleModel styleModel = GetCorrespondingStyle(styleProvider);
            styleModel?.BindStyle(mediaElement);

            return (T) Convert.ChangeType(mediaElement, typeof(T));
        }
    }
}
