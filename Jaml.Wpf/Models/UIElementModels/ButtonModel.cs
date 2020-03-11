using System.Windows.Controls.Primitives;
using Jaml.Wpf.Models.CommandModels;
using Jaml.Wpf.Models.StyleModels;
using Jaml.Wpf.Parsers;
using Jaml.Wpf.Providers.CommandProvider;
using Jaml.Wpf.Providers.StyleProvider;

namespace Jaml.Wpf.Models.UIElementModels
{
    // ReSharper disable once ClassNeverInstantiated.Global

    /// <summary>
    /// Model of button
    /// </summary>
    public class ButtonModel : FrameworkElementModel
    {
        /// <summary>
        /// Creates button from model
        /// </summary>
        /// <typeparam name="T">Children of <see cref="ButtonBase"/></typeparam>
        /// <param name="button">Target button</param>
        /// <param name="commandProvider">Command provider</param>
        /// <param name="styleProvider">Style provider</param>
        public void ToButton<T>(ref T button, ICommandProvider commandProvider, IStyleProvider styleProvider) where T : ButtonBase
        {
            button.Content = Content;
            button.VerticalAlignment = PropertyParser.ParseVerticalAlignment(VerticalAlignment);
            button.HorizontalAlignment = PropertyParser.ParseHorizontalAlignment(HorizontalAlignment);

            foreach (ICommandModel commandModel in Commands) commandModel.BindCommand(ref button, commandProvider);

            IStyleModel styleModel = GetCorrespondingStyle(styleProvider);
            styleModel?.BindStyle(ref button);
        }
    }
}
