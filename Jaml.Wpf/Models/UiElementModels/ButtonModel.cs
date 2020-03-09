using System;
using System.Windows.Controls;
using Jaml.Wpf.Models.CommandModels;
using Jaml.Wpf.Models.StyleModels;
using Jaml.Wpf.Parsers;
using Jaml.Wpf.Providers.CommandProvider;
using Jaml.Wpf.Providers.StyleProvider;

namespace Jaml.Wpf.Models.UiElementModels
{
    // ReSharper disable once ClassNeverInstantiated.Global

    /// <summary>
    /// Model of button
    /// </summary>
    public class ButtonModel : UiElementModel
    {
        /// <inheritdoc />
        public override T ToUiElement<T>(ICommandProvider commandProvider, IStyleProvider styleProvider)
        {
            Button button = new Button
            {
                Content = Content,
                VerticalAlignment = PropertyParser.ParseVerticalAlignment(VerticalAlignment),
                HorizontalAlignment = PropertyParser.ParseHorizontalAlignment(HorizontalAlignment)
            };

            foreach (ICommandModel commandModel in Commands) commandModel.BindCommand(button, commandProvider);

            IStyleModel styleModel = GetCorrespondingStyle(styleProvider);
            styleModel?.BindStyle(button);

            return (T) Convert.ChangeType(button, typeof(T));
        }
    }
}
