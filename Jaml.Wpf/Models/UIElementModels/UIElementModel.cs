using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows;
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
        [JsonPropertyName("Name")]
        public string Name { get; set; } = null;

        /// <inheritdoc />
        [JsonPropertyName("VerticalAlignment")]
        public string VerticalAlignment { get; set; } = null;

        /// <inheritdoc />
        [JsonPropertyName("HorizontalAlignment")]
        public string HorizontalAlignment { get; set; } = null;

        /// <inheritdoc />
        [JsonPropertyName("Content")]
        public string Content { get; set; } = null;

        /// <inheritdoc />
        [JsonPropertyName("StyleId")]
        public int StyleId { get; set; } = -1;

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
        public void ToUIElement<T>(ref T element, ICommandProvider commandProvider) where T : UIElement
        {
            //Bind properties
            //todo
            element.AllowDrop = AllowDrop;
            element.CacheMode = default;
            element.ClipToBounds = ClipToBounds;
            element.Clip = default; //default null
            element.Effect = default;
            element.Focusable = Focusable;
            element.IsEnabled = IsEnabled;
            element.IsHitTestVisible = IsHitTestVisible;
            element.IsManipulationEnabled = IsManipulationEnabled;
            element.Opacity = Opacity;
            element.OpacityMask = default;
            element.RenderSize = default;
            element.RenderTransform = default;
            element.RenderTransformOrigin = default;
            element.SnapsToDevicePixels = SnapsToDevicePixels;
            element.Uid = Uid;
            element.Visibility = Parsers.PropertyParser.ParseVisibility(Visibility);

            //Bind commands
            commandProvider.BindCommands(ref element, Commands);
        }

        #region New props

        /// <summary>
        /// 
        /// </summary>
        public bool AllowDrop { get; set; } = false;

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
