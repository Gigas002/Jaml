using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Media;
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

        /// <inheritdoc />
        [JsonPropertyName("AllowDrop")]
        public bool AllowDrop { get; set; } = false;

        /// <inheritdoc />
        [JsonPropertyName("Clip")]
        public string Clip { get; set; } = string.Empty;

        /// <inheritdoc />
        [JsonPropertyName("ClipToBounds")]
        public bool ClipToBounds { get; set; } = false;

        /// <inheritdoc />
        [JsonPropertyName("Focusable")]
        public bool Focusable { get; set; } = false;

        /// <inheritdoc />
        [JsonPropertyName("IsEnabled")]
        public bool IsEnabled { get; set; } = true;

        /// <inheritdoc />
        [JsonPropertyName("IsHitTestVisible")]
        public bool IsHitTestVisible { get; set; } = true;

        /// <inheritdoc />
        [JsonPropertyName("IsManipulationEnabled")]
        public bool IsManipulationEnabled { get; set; } = false;

        /// <inheritdoc />
        [JsonPropertyName("Opacity")]
        public double Opacity { get; set; } = 1.0;

        /// <inheritdoc />
        [JsonPropertyName("RenderSize")]
        public string RenderSize { get; set; } = string.Empty;

        /// <inheritdoc />
        [JsonPropertyName("RenderTransform")]
        public string RenderTransform { get; set; } = string.Empty;

        /// <inheritdoc />
        [JsonPropertyName("RenderTransformOrigin")]
        public string RenderTransformOrigin { get; set; } = string.Empty;

        /// <inheritdoc />
        [JsonPropertyName("SnapsToDevicePixels")]
        public bool SnapsToDevicePixels { get; set; } = false;

        /// <inheritdoc />
        [JsonPropertyName("Uid")]
        public string Uid { get; set; } = string.Empty;

        /// <inheritdoc />
        [JsonPropertyName("Visibility")]
        public string Visibility { get; set; } = string.Empty;

        #region TODO

        /// <inheritdoc />
        public object CacheMode { get; set; }

        /// <inheritdoc />
        public object Effect { get; set; }

        /// <inheritdoc />
        public object OpacityMask { get; set; }

        #endregion

        #endregion

        #region Methods

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
            //element.CacheMode = default;
            if (!string.IsNullOrWhiteSpace(Clip))
                element.Clip = Geometry.Parse(Clip);
            element.ClipToBounds = ClipToBounds;
            //element.Effect = default;
            element.Focusable = Focusable;
            element.IsEnabled = IsEnabled;
            element.IsHitTestVisible = IsHitTestVisible;
            element.IsManipulationEnabled = IsManipulationEnabled;
            element.Opacity = Opacity;
            //element.OpacityMask = default;
            if (!string.IsNullOrWhiteSpace(RenderSize))
                element.RenderSize = Size.Parse(RenderSize);
            if (!string.IsNullOrWhiteSpace(RenderTransform))
                element.RenderTransform = Transform.Parse(RenderTransform);
            if (!string.IsNullOrWhiteSpace(RenderTransformOrigin))
                element.RenderTransformOrigin = Point.Parse(RenderTransformOrigin);
            element.SnapsToDevicePixels = SnapsToDevicePixels;
            element.Uid = Uid;
            Enum.TryParse(Visibility, out Visibility visibility);
            element.Visibility = visibility;
        }

        #endregion
    }
}
