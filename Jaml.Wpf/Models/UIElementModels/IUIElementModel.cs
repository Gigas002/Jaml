using System.Collections.Generic;
using System.Windows;
using Jaml.Wpf.Models.CommandModels;
using Jaml.Wpf.Providers.CommandProvider;
using Jaml.Wpf.Providers.StyleProvider;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMemberInSuper.Global

namespace Jaml.Wpf.Models.UIElementModels
{
    /// <summary>
    /// Base interface for all <see cref="UIElement"/> on page
    /// </summary>
    /// <typeparam name="T">Children of <see cref="UIElement"/></typeparam>
    public interface IUIElementModel<T> where T : UIElement, new()
    {
        #region Properties

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
        /// Allow drop
        /// </summary>
        public bool AllowDrop { get; }

        /// <summary>
        /// Clip
        /// </summary>
        public string Clip { get; }

        /// <summary>
        /// Clip to bounds
        /// </summary>
        public bool ClipToBounds { get; }

        /// <summary>
        /// Focusable
        /// </summary>
        public bool Focusable { get; }

        /// <summary>
        /// Is enabled
        /// </summary>
        public bool IsEnabled { get; }

        /// <summary>
        /// Is hit test visible
        /// </summary>
        public bool IsHitTestVisible { get; }

        /// <summary>
        /// Is manipulation enabled
        /// </summary>
        public bool IsManipulationEnabled { get; }

        /// <summary>
        /// Opacity
        /// </summary>
        public double Opacity { get; }

        /// <summary>
        /// Render size
        /// </summary>
        public string RenderSize { get; }

        /// <summary>
        /// Render transform
        /// </summary>
        public string RenderTransform { get; }

        /// <summary>
        /// Render transform origin
        /// </summary>
        public string RenderTransformOrigin { get; }

        /// <summary>
        /// Snaps to device pixels
        /// </summary>
        public bool SnapsToDevicePixels { get; }

        /// <summary>
        /// Uid
        /// </summary>
        public string Uid { get; }

        /// <summary>
        /// Visibility
        /// </summary>
        public string Visibility { get; }

        #region TODO

        /// <summary>
        /// 
        /// </summary>
        public object CacheMode { get; }

        /// <summary>
        /// 
        /// </summary>
        public object Effect { get; }

        /// <summary>
        /// 
        /// </summary>
        public object OpacityMask { get; }

        #endregion

        #endregion

        #region Methods

        /// <summary>
        /// Converts this model to one of <see cref="UIElement"/>'s children
        /// </summary>
        /// <param name="commandProvider">Command provider</param>
        /// <param name="styleProvider">Style provider</param>
        /// <returns>Converted element</returns>
        public T ToUIElement(ICommandProvider commandProvider, IStyleProvider styleProvider);

        /// <summary>
        /// Bind this model properties to the target <see cref="UIElement"/>
        /// </summary>
        /// <param name="element">Target element</param>
        /// <param name="commandProvider">Command provider</param>
        /// <param name="styleProvider">Style provider</param>
        public void BindProperties(T element, ICommandProvider commandProvider, IStyleProvider styleProvider);

        /// <summary>
        /// Binds command to passed element
        /// </summary>
        /// <param name="element">Target element to bind the command</param>
        /// <param name="commandModel">Model of command for element</param>
        /// <param name="commandProvider">Command provider</param>
        public void BindCommand(T element, ICommandModel commandModel, ICommandProvider commandProvider);

        /// <summary>
        /// Binds commands to passed element
        /// </summary>
        /// <param name="element">Target element to bind the command</param>
        /// <param name="commandProvider">Command provider</param>
        public void BindCommands(T element, ICommandProvider commandProvider);

        #endregion
    }
}
