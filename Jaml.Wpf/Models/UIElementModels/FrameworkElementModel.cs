using System;
using System.Text.Json.Serialization;
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
        #region Properties

        /// <summary>
        /// Style id to use on this element
        /// </summary>
        [JsonPropertyName("StyleId")]
        public int StyleId { get; set; } = -1;

        /// <summary>
        /// Name of element
        /// </summary>
        [JsonPropertyName("Name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Vertical alignment
        /// </summary>
        [JsonPropertyName("VerticalAlignment")]
        public string VerticalAlignment { get; set; } = string.Empty;

        /// <summary>
        /// Horizontal alignment
        /// </summary>
        [JsonPropertyName("HorizontalAlignment")]
        public string HorizontalAlignment { get; set; } = string.Empty;

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

            Enum.TryParse(VerticalAlignment, out VerticalAlignment verticalAlignment);
            Enum.TryParse(HorizontalAlignment, out HorizontalAlignment horizontalAlignment);
            element.VerticalAlignment = verticalAlignment;
            element.HorizontalAlignment = horizontalAlignment;

            element.BindingGroup = default;
            element.ContextMenu = default;
            element.Cursor = default;

            ////element.DataContext =

            Enum.TryParse(FlowDirection, out FlowDirection flowDirection);
            element.FlowDirection = flowDirection;
            ////element.FocusVisualStyle =
            element.ForceCursor = ForceCursor;
            //element.Height = Height;
            ////element.InputScope
            ////element.Language = XmlLanguage.GetLanguage(Language);
            ////element.LayoutTransform = Transform.Parse(LayoutTransform);
            element.Margin = new Thickness(Margin);
            //element.MaxHeight = MaxHeight;
            //element.MaxWidth = MaxWidth;
            //element.MinHeight = MinHeight;
            //element.MinWidth = MinWidth;
            element.OverridesDefaultStyle = OverridesDefaultStyle;
            ////element.Resources;
            ////element.Tag;
            ////element.ToolTip;
            element.UseLayoutRounding = UseLayoutRounding;
            //element.Width = Width;
        }

        public bool ForceCursor { get; set; }

        public double Height { get; set; } = 500;

        public string FlowDirection { get; set; } = string.Empty;

        public string Language { get; set; } = string.Empty;

        public string LayoutTransform { get; set; } = string.Empty;

        public bool UseLayoutRounding { get; set; }

        public double Margin { get; set; }

        public double MaxHeight { get; set; } = 500;

        public double MaxWidth { get; set; } = 500;

        public double MinHeight { get; set; } = 500;

        public double MinWidth { get; set; } = 500;

        public bool OverridesDefaultStyle { get; set; }

        public double Width { get; set; } = 500;
    }
}
