using System.Windows;

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
        /// Background of the control
        /// </summary>
        public string Background { get; }

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
    }
}
