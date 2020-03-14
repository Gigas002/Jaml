using System;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
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
        /// Flow direction (default left to right)
        /// </summary>
        [JsonPropertyName("FlowDirection")]
        public string FlowDirection { get; set; } = string.Empty;

        /// <summary>
        /// Force cursor
        /// </summary>
        [JsonPropertyName("ForceCursor")]
        public bool ForceCursor { get; set; } = false;

        /// <summary>
        /// Height
        /// </summary>
        [JsonPropertyName("Height")]
        public double Height { get; set; } = double.NaN;

        /// <summary>
        /// Horizontal alignment
        /// </summary>
        [JsonPropertyName("HorizontalAlignment")]
        public string HorizontalAlignment { get; set; } = string.Empty;

        /// <summary>
        /// Language
        /// </summary>
        [JsonPropertyName("Language")]
        public string Language { get; set; } = string.Empty;

        /// <summary>
        /// Layout transform
        /// </summary>
        [JsonPropertyName("LayoutTransform")]
        public string LayoutTransform { get; set; } = string.Empty;

        /// <summary>
        /// Margin
        /// </summary>
        [JsonPropertyName("Margin")]
        public double Margin { get; set; } = 0.0;

        /// <summary>
        /// Max height
        /// </summary>
        [JsonPropertyName("MaxHeight")]
        public double MaxHeight { get; set; } = double.PositiveInfinity;

        /// <summary>
        /// Max width
        /// </summary>
        [JsonPropertyName("MaxWidth")]
        public double MaxWidth { get; set; } = double.PositiveInfinity;

        /// <summary>
        /// Min height
        /// </summary>
        [JsonPropertyName("MinHeight")]
        public double MinHeight { get; set; } = 0.0;

        /// <summary>
        /// min width
        /// </summary>
        [JsonPropertyName("MinWidth")]
        public double MinWidth { get; set; } = 0.0;

        /// <summary>
        /// Name of element
        /// </summary>
        [JsonPropertyName("Name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Overrides default style
        /// </summary>
        [JsonPropertyName("OverridesDefaultStyle")]
        public bool OverridesDefaultStyle { get; set; } = false;

        /// <summary>
        /// Use layout rounding
        /// </summary>
        [JsonPropertyName("UseLayoutRounding")]
        public bool UseLayoutRounding { get; set; } = false;

        /// <summary>
        /// Vertical alignment
        /// </summary>
        [JsonPropertyName("VerticalAlignment")]
        public string VerticalAlignment { get; set; } = string.Empty;

        /// <summary>
        /// Width
        /// </summary>
        [JsonPropertyName("Width")]
        public double Width { get; set; } = double.NaN;

        #region TODO

        public object BindingGroup { get; set; }
        public object ContextMenu { get; set; }
        public object Cursor { get; set; }
        public object DataContext { get; set; }
        public object FocusVisualStyle { get; set; }
        public object InputScope { get; set; }
        public object Resources { get; set; }
        public object Style { get; set; }
        public object Tag { get; set; }
        public object Tooltip { get; set; }

        #endregion

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

            //element.BindingGroup = default;
            //element.ContextMenu = default;
            //element.Cursor = default;
            //element.DataContext =
            Enum.TryParse(FlowDirection, out FlowDirection flowDirection);
            element.FlowDirection = flowDirection;
            //element.FocusVisualStyle =
            element.ForceCursor = ForceCursor;
            element.Height = Height;
            Enum.TryParse(HorizontalAlignment, out HorizontalAlignment horizontalAlignment);
            element.HorizontalAlignment = horizontalAlignment;
            //element.InputScope
            if (!string.IsNullOrWhiteSpace(Language))
                element.Language = XmlLanguage.GetLanguage(Language);
            if (!string.IsNullOrWhiteSpace(LayoutTransform))
                element.LayoutTransform = Transform.Parse(LayoutTransform);
            element.Margin = new Thickness(Margin);
            element.MaxHeight = MaxHeight;
            element.MaxWidth = MaxWidth;
            element.MinHeight = MinHeight;
            element.MinWidth = MinWidth;
            element.Name = Name;
            element.OverridesDefaultStyle = OverridesDefaultStyle;
            //element.Resources;
            //element.Style = style;
            //element.Tag;
            //element.ToolTip;
            element.UseLayoutRounding = UseLayoutRounding;
            Enum.TryParse(VerticalAlignment, out VerticalAlignment verticalAlignment);
            element.VerticalAlignment = verticalAlignment;
            element.Width = Width;
        }
    }
}
