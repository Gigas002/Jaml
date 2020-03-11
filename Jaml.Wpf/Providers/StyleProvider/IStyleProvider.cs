using System.Collections.Generic;
using System.Windows;
using Jaml.Wpf.Models.StyleModels;

namespace Jaml.Wpf.Providers.StyleProvider
{
    /// <summary>
    /// Base interface for style operations
    /// </summary>
    public interface IStyleProvider
    {
        /// <summary>
        /// Dictionary of styles. Key is id, and Value is style model
        /// </summary>
        public Dictionary<int, IStyleModel> Styles { get; }

        /// <summary>
        /// Registers all styles from dictionary
        /// </summary>
        /// <param name="styles">Dictionary to register</param>
        public void RegisterStyles(Dictionary<int, IStyleModel> styles);

        /// <summary>
        /// Delete collection of styles with specified keys
        /// </summary>
        /// <param name="styleIds">Collection of keys to delete from dictionary</param>
        public void UnregisterStyles(IEnumerable<int> styleIds);

        /// <summary>
        /// Clears dictionary of styles
        /// </summary>
        public void ClearStyles();

        /// <summary>
        /// Registers one style
        /// </summary>
        /// <param name="styleId">Id of style</param>
        /// <param name="styleModel">Style model</param>
        public void RegisterStyle(int styleId, IStyleModel styleModel);

        /// <summary>
        /// Delete the specified style from dictionary
        /// </summary>
        /// <param name="styleId">Id of style</param>
        public void UnregisterStyle(int styleId);

        /// <summary>
        /// Gets style by name
        /// </summary>
        /// <param name="styleId">Id of style to get</param>
        /// <returns>Command's <see cref="IStyleModel"/></returns>
        public IStyleModel GetStyle(int styleId);

        /// <summary>
        /// Bind style to element
        /// </summary>
        /// <typeparam name="T">Children of <see cref="FrameworkElement"/></typeparam>
        /// <param name="element">Target element to bind the style</param>
        /// <param name="styleId">Id of style to bind to element</param>
        public void BindStyle<T>(ref T element, int styleId) where T : FrameworkElement;
    }
}
