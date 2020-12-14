using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using Jaml.Wpf.Exceptions;
using Jaml.Wpf.Models.CommandModels;
using Jaml.Wpf.Models.StyleModels;
using Jaml.Wpf.Providers.CommandProviders;

// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace Jaml.Wpf.Models.UIElementModels
{
    /// <summary>
    /// Base FrameworkElement model
    /// </summary>
    /// <typeparam name="T">Children of <see cref="FrameworkElement"/></typeparam>
    public class FrameworkElementModel<T> : UIElementModel<T>, IUIElementModel<T> where T : FrameworkElement, new()
    {
        #region Properties

        /// <summary>
        /// Style id to use on this element
        /// </summary>
        [JsonPropertyName("StyleId")]
        public int StyleId { get; set; } = -1;

        /// <summary>
        /// Focus visual style id to use on this element
        /// </summary>
        [JsonPropertyName("FocusVisualStyleId")]
        public int FocusVisualStyleId { get; set; } = -1;

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
        public object InputScope { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object Resources { get; set; }

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

        #region EventNames

        internal const string ContextMenuClosing = nameof(ContextMenuClosing);
        internal const string ContextMenuOpening = nameof(ContextMenuOpening);
        internal const string DataContextChanged = nameof(DataContextChanged);
        internal const string Initialized = nameof(Initialized);
        internal const string Loaded = nameof(Loaded);
        internal const string RequestBringIntoView = nameof(RequestBringIntoView);
        internal const string SizeChanged = nameof(SizeChanged);
        internal const string SourceUpdated = nameof(SourceUpdated);
        internal const string TargetUpdated = nameof(TargetUpdated);
        internal const string ToolTipClosing = nameof(ToolTipClosing);
        internal const string ToolTipOpening = nameof(ToolTipOpening);
        internal const string Unloaded = nameof(Unloaded);

        #endregion

        #region Methods

        /// <inheritdoc />
        public override T ToUIElement(ICommandProvider commandProvider = null, IList<StyleModel> styleModels = null)
        {
            T element = base.ToUIElement(commandProvider, styleModels);

            BindProperties(element, null, styleModels);

            BindCommands(element, commandProvider);

            return element;
        }

        /// <inheritdoc />
        public new void BindProperties(T element, ICommandProvider commandProvider = null,
                                       IList<StyleModel> styleModels = null)
        {
            if (element is null) throw new UIException(nameof(element));

            //element.BindingGroup = default;
            //element.ContextMenu = default;
            //element.Cursor = default;
            //element.DataContext =
            bool isParsed = Enum.TryParse(FlowDirection, out FlowDirection flowDirection);
            element.FlowDirection = isParsed ? flowDirection : default;

            //Bind focus visual style
            element.FocusVisualStyle = StyleModel.TryGetStyle<Style>(styleModels, FocusVisualStyleId);

            element.ForceCursor = ForceCursor;
            element.Height = Height;
            isParsed = Enum.TryParse(HorizontalAlignment, out HorizontalAlignment horizontalAlignment);
            element.HorizontalAlignment = isParsed ? horizontalAlignment : default;
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

            //Bind style
            element.Style = StyleModel.TryGetStyle<Style>(styleModels, StyleId);

            //element.Tag;
            //element.ToolTip;
            element.UseLayoutRounding = UseLayoutRounding;
            isParsed = Enum.TryParse(VerticalAlignment, out VerticalAlignment verticalAlignment);
            element.VerticalAlignment = isParsed ? verticalAlignment : default;
            element.Width = Width;
        }

        /// <inheritdoc />
        public new void BindCommand(T element, ICommandModel commandModel, ICommandProvider commandProvider)
        {
            if (element is null) throw new UIException(nameof(element));
            if (commandModel is null) throw new UIException(nameof(commandModel));

            if (commandProvider is null) return;

            string eventName = commandModel.EventName;
            string methodName = commandModel.Method;
            IEnumerable<ICommandArgModel> methodArgs = commandModel.Args;

            switch (eventName)
            {
                case ContextMenuClosing:
                {
                    element.ContextMenuClosing += (sender, args) =>
                        commandProvider.RunCommand(methodName, sender, methodArgs);

                    break;
                }
                case ContextMenuOpening:
                {
                    element.ContextMenuOpening += (sender, args) =>
                        commandProvider.RunCommand(methodName, sender, methodArgs);

                    break;
                }
                case DataContextChanged:
                {
                    element.DataContextChanged += (sender, args) =>
                        commandProvider.RunCommand(methodName, sender, methodArgs);

                    break;
                }
                case Initialized:
                {
                    element.Initialized += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                    break;
                }
                case Loaded:
                {
                    element.Loaded += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                    break;
                }
                case RequestBringIntoView:
                {
                    element.RequestBringIntoView += (sender, args) =>
                        commandProvider.RunCommand(methodName, sender, methodArgs);

                    break;
                }
                case SizeChanged:
                {
                    element.SizeChanged += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                    break;
                }
                case SourceUpdated:
                {
                    element.SourceUpdated += (sender, args) =>
                        commandProvider.RunCommand(methodName, sender, methodArgs);

                    break;
                }
                case TargetUpdated:
                {
                    element.TargetUpdated += (sender, args) =>
                        commandProvider.RunCommand(methodName, sender, methodArgs);

                    break;
                }
                case ToolTipClosing:
                {
                    element.ToolTipClosing += (sender, args) =>
                        commandProvider.RunCommand(methodName, sender, methodArgs);

                    break;
                }
                case ToolTipOpening:
                {
                    element.ToolTipOpening += (sender, args) =>
                        commandProvider.RunCommand(methodName, sender, methodArgs);

                    break;
                }

                case Unloaded:
                {
                    element.Unloaded += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                    break;
                }

                default:
                {
                    break;
                    //throw new NotSupportedException($"Event {eventName} is not supported.");
                }
            }
        }

        /// <inheritdoc />
        public new void BindCommands(T element, ICommandProvider commandProvider)
        {
            foreach (ICommandModel commandModel in Commands)
                BindCommand(element, commandModel, commandProvider);
        }

        #endregion
    }
}
