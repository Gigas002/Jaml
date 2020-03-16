using System;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using Jaml.Wpf.Providers.CommandProvider;
using Jaml.Wpf.Providers.StyleProvider;

// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

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

        /// <summary>
        /// 
        /// </summary>
        public object BindingGroup { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object ContextMenu { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object Cursor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object DataContext { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object FocusVisualStyle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object InputScope { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object Resources { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object Style { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object Tooltip { get; set; }

        #endregion

        #endregion

        #region Methods

        /// <summary>
        /// Converts this model to one of <see cref="FrameworkElement"/>'s children
        /// </summary>
        /// <typeparam name="T">Children of <see cref="FrameworkElement"/></typeparam>
        /// <param name="element">Element, where model will be converted</param>
        /// <param name="commandProvider">Command provider</param>
        /// <param name="styleProvider">Style provider</param>
        public void ToFrameworkElement<T>(ref T element, ICommandProvider commandProvider, IStyleProvider styleProvider) where T : FrameworkElement
        {
            //Bind properties
            BindProperties(ref element, commandProvider, styleProvider);
        }

        /// <summary>
        /// Binds this element's properties
        /// </summary>
        /// <typeparam name="T">Children of <see cref="FrameworkElement"/></typeparam>
        /// <param name="element">Target element to bind properties</param>
        /// <param name="commandProvider">Command provider</param>
        /// <param name="styleProvider">Style provider</param>
        public new void BindProperties<T>(ref T element, ICommandProvider commandProvider, IStyleProvider styleProvider) where T : FrameworkElement
        {
            base.BindProperties(ref element, commandProvider, styleProvider);

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

            //todo bind style only here, not in children
            //element.Style = style;
            //Bind style
            styleProvider.BindStyle(ref element, StyleId);

            //element.Tag;
            //element.ToolTip;
            element.UseLayoutRounding = UseLayoutRounding;
            Enum.TryParse(VerticalAlignment, out VerticalAlignment verticalAlignment);
            element.VerticalAlignment = verticalAlignment;
            element.Width = Width;
        }

        #endregion
    }
}
