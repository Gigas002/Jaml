using System.Collections.Generic;
using System.Windows;
using Jaml.Wpf.Models.CommandModels;
using Jaml.Wpf.Providers.CommandProvider;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMemberInSuper.Global

namespace Jaml.Wpf.Models.UIElementModels
{
    /// <summary>
    /// Base interface for all <see cref="UIElement"/> on page
    /// </summary>
    public interface IUIElementModel
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

        public object CacheMode { get; }
        public object Effect { get; }
        public object OpacityMask { get; }

        #endregion

        #endregion

        #region Methods

        /// <summary>
        /// Converts this model to one of <see cref="UIElement"/>'s children
        /// </summary>
        /// <typeparam name="T">Children of <see cref="UIElement"/></typeparam>
        /// <param name="element">Element, where model will be converted</param>
        /// <param name="commandProvider">Command provider</param>
        public void ToUIElement<T>(ref T element, ICommandProvider commandProvider) where T : UIElement;

        /// <summary>
        /// Bind this model properties to the target <see cref="UIElement"/>
        /// </summary>
        /// <typeparam name="T">Children of<see cref="UIElement"/></typeparam>
        /// <param name="element">Target element</param>
        public void BindProperties<T>(ref T element) where T : UIElement;

        #endregion
    }
}
