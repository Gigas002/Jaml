using System.Windows;
using Jaml.Wpf.Models.UIElementModels;

namespace Jaml.Wpf.Models.StyleModels
{
    /// <summary>
    /// Base interface for all style models
    /// </summary>
    public interface IStyleModel
    {
        /// <summary>
        /// Style id
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Font size
        /// </summary>
        public double FontSize { get; }

        /// <summary>
        /// Font family path
        /// </summary>
        public string FontFamily { get; }

        /// <summary>
        /// Font size
        /// </summary>
        public string FontStyle { get; }

        /// <summary>
        /// Font weight
        /// </summary>
        public string FontWeight { get; }

        /// <summary>
        /// Foreground Argb string
        /// </summary>
        public string Foreground { get; }

        /// <summary>
        ///todo
        /// Background of the control
        /// </summary>
        public BackgroundModel Background { get; }

        /// <summary>
        /// Border thickness
        /// </summary>
        public double BorderThickness { get; }

        /// <summary>
        /// Visibility
        /// </summary>
        public string Visibility { get; }

        /// <summary>
        /// Convert current model to style
        /// </summary>
        /// <typeparam name="T">Children of <see cref="Style"/></typeparam>
        /// <returns>Converted style</returns>
        public void ToStyle<T>(ref T style) where T : Style;

        /// <summary>
        /// Bind style to element
        /// </summary>
        /// <typeparam name="T">Children of <see cref="FrameworkElement"/></typeparam>
        /// <param name="element">Target element to bind the style</param>
        public void BindStyle<T>(ref T element) where T : FrameworkElement;
    }
}
