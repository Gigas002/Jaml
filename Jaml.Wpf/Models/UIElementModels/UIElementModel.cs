using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using Jaml.Wpf.Models.CommandModels;
using Jaml.Wpf.Providers.CommandProvider;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace Jaml.Wpf.Models.UIElementModels
{
    /// <summary>
    /// Base class, that implements <see cref="IUIElementModel"/>
    /// </summary>
    public class UIElementModel : IUIElementModel
    {
        #region Json Properties

        /// <inheritdoc />
        [JsonPropertyName("ParentRow")]
        public int ParentRow { get; set; } = 0;

        /// <inheritdoc />
        [JsonPropertyName("ParentColumn")]
        public int ParentColumn { get; set; } = 0;

        /// <inheritdoc />
        [JsonPropertyName("RowSpan")]
        public int RowSpan { get; set; } = 1;

        /// <inheritdoc />
        [JsonPropertyName("ColumnSpan")]
        public int ColumnSpan { get; set; } = 1;

        /// <inheritdoc />
        [JsonPropertyName("Commands")]
        public IEnumerable<CommandModel> Commands { get; set; } = new List<CommandModel>();

        #endregion

        /// <inheritdoc />
        public virtual void ToUIElement<T>(ref T element, ICommandProvider commandProvider) where T : UIElement
        {
            //Bind properties
            BindProperties(ref element);

            //Bind commands
            commandProvider.BindCommands(ref element, Commands);
        }

        /// <inheritdoc />
        public virtual void BindProperties<T>(ref T element) where T : UIElement
        {
            //todo
            element.AllowDrop = AllowDrop;
            element.CacheMode = default;
            element.ClipToBounds = ClipToBounds;
            //element.Clip = Geometry.Parse(Clip);
            element.Effect = default;
            element.Focusable = Focusable;
            element.IsEnabled = IsEnabled;
            element.IsHitTestVisible = IsHitTestVisible;
            element.IsManipulationEnabled = IsManipulationEnabled;
            element.Opacity = Opacity;
            element.OpacityMask = default;
            //element.RenderSize = Size.Parse(RenderSize);
            //element.RenderTransform = Transform.Parse(RenderTransform);
            //element.RenderTransformOrigin = Point.Parse(RenderTransformOrigin);
            element.SnapsToDevicePixels = SnapsToDevicePixels;
            element.Uid = Uid;
            Enum.TryParse(Visibility, out Visibility visibility);
            element.Visibility = visibility;
        }

        #region New props

        /// <summary>
        /// 
        /// </summary>
        public bool AllowDrop { get; set; } = false;

        public string Clip { get; set; } = null;

        /// <summary>
        /// 
        /// </summary>
        public bool ClipToBounds { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        public bool Focusable { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// 
        /// </summary>
        public bool IsHitTestVisible { get; set; } = true;

        /// <summary>
        /// 
        /// </summary>
        public bool IsManipulationEnabled { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        public double Opacity { get; set; } = 1.0;

        public string RenderSize { get; set; } = null;

        public string RenderTransform { get; set; } = null;

        public string RenderTransformOrigin { get; set; } = null;

        /// <summary>
        /// 
        /// </summary>
        public bool SnapsToDevicePixels { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        public string Uid { get; set; } = null;

        /// <summary>
        /// 
        /// </summary>
        public string Visibility { get; set; } = null;

        #endregion
    }
}
