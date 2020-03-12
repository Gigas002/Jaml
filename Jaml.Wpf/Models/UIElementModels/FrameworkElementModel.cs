using System.Text.Json.Serialization;
using System.Windows;
using Jaml.Wpf.Parsers;
using Jaml.Wpf.Providers.CommandProvider;
using Jaml.Wpf.Providers.StyleProvider;

namespace Jaml.Wpf.Models.UIElementModels
{
    /// <summary>
    /// Base FrameworkElement model
    /// </summary>
    public class FrameworkElementModel : UIElementModel
    {
        #region Properties

        /// <summary>
        /// Name of element
        /// </summary>
        [JsonPropertyName("Name")]
        public string Name { get; set; } = null;

        /// <summary>
        /// Vertical alignment
        /// </summary>
        [JsonPropertyName("VerticalAlignment")]
        public string VerticalAlignment { get; set; } = null;

        /// <summary>
        /// Horizontal alignment
        /// </summary>
        [JsonPropertyName("HorizontalAlignment")]
        public string HorizontalAlignment { get; set; } = null;

        /// <summary>
        /// Style id to use on this element
        /// </summary>
        [JsonPropertyName("StyleId")]
        public int StyleId { get; set; } = -1;

        #endregion

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

            //Bind properties
            BindProperties(ref element);

            //Bind commands
            commandProvider.BindCommands(ref element, Commands);
        }

        public new void BindProperties<T>(ref T element) where T : FrameworkElement
        {
            //todo
            base.BindProperties(ref element);
            element.Name = Name;
            element.VerticalAlignment = PropertyParser.ParseVerticalAlignment(VerticalAlignment);
            element.HorizontalAlignment = PropertyParser.ParseHorizontalAlignment(HorizontalAlignment);
        }
    }
}
