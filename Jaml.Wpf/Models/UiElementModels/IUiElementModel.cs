using System.Collections.Generic;
using System.Windows;
using Jaml.Wpf.Models.CommandModels;
using Jaml.Wpf.Models.StyleModels;
using Jaml.Wpf.Providers.CommandProvider;
using Jaml.Wpf.Providers.StyleProvider;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMemberInSuper.Global

namespace Jaml.Wpf.Models.UIElementModels
{
    /// <summary>
    /// Base interface for all <see cref="UIElement"/> on page
    /// </summary>
    public interface IUIElementModel
    {
        /// <summary>
        /// Name of element
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Vertical alignment
        /// </summary>
        public string VerticalAlignment { get; }

        /// <summary>
        /// Horizontal alignment
        /// </summary>
        public string HorizontalAlignment { get; }

        /// <summary>
        /// Element's content
        /// </summary>
        public string Content { get; }

        /// <summary>
        /// Style id to use on this element
        /// </summary>
        public int StyleId { get; }

        /// <summary>
        /// Row position in parent grid
        /// </summary>
        public int ParentRow { get; }

        /// <summary>
        /// Column position in parent grid
        /// </summary>
        public int ParentColumn { get; }

        /// <summary>
        /// RowSpan in parent grid
        /// </summary>
        public int RowSpan { get; }

        /// <summary>
        /// ColumnSpan in parent grid
        /// </summary>
        public int ColumnSpan { get; }

        /// <summary>
        /// Collection of commands, associated with this element
        /// </summary>
        public IEnumerable<CommandModel> Commands { get; }

        /// <summary>
        /// Converts this model to one of <see cref="UIElement"/>'s children
        /// </summary>
        /// <typeparam name="T">Children of <see cref="UIElement"/></typeparam>
        /// <param name="element">Element, where model will be converted</param>
        /// <param name="commandProvider">Command provider</param>
        /// <param name="styleProvider">Style provider</param>
        public void ToUIElement<T>(ref T element, ICommandProvider commandProvider, IStyleProvider styleProvider) where T : UIElement;

        /// <summary>
        /// Checks if there is a style for this element
        /// </summary>
        /// <param name="styleProvider">Style provider</param>
        /// <returns>Corresponding style model or <see langword="null"/></returns>
        public IStyleModel GetCorrespondingStyle(IStyleProvider styleProvider);
    }
}
