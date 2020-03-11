using System.Windows;
using Jaml.Wpf.Providers.CommandProvider;
using Jaml.Wpf.Providers.StyleProvider;

namespace Jaml.Wpf.Models.UIElementModels
{
    /// <summary>
    /// Base FrameworkElement model
    /// </summary>
    public class FrameworkElementModel : UIElementModel
    {
        /// <summary>
        /// Converts this model to one of <see cref="FrameworkElement"/>'s children
        /// </summary>
        /// <typeparam name="T">Children of <see cref="FrameworkElement"/></typeparam>
        /// <param name="element">Element, where model will be converted</param>
        /// <param name="commandProvider">Command provider</param>
        /// <param name="styleProvider">Style provider</param>
        public void ToFrameworkElement<T>(ref T element, ICommandProvider commandProvider, IStyleProvider styleProvider) where T : FrameworkElement
        {
            //Bind style
            styleProvider.BindStyle(ref element, StyleId);

            //Explicitly initialized properties should override styles

            //Bind basic properties by parent
            ToUIElement(ref element, commandProvider);

            //Bind specific properties
            //todo

            //Bind commands
            commandProvider.BindCommands(ref element, Commands);
        }
    }
}
