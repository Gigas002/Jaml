using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Jaml.Wpf.Exceptions;
using Jaml.Wpf.Models.CommandModels;
using Jaml.Wpf.Models.StyleModels;
using Jaml.Wpf.Providers.CommandProviders;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace Jaml.Wpf.Models.UIElementModels
{
    // ReSharper disable once InconsistentNaming

    /// <inheritdoc />
    public class UIElementModel<T> : IUIElementModel<T> where T : UIElement, new()
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

        #region EventNames

        internal const string DragEnter = nameof(DragEnter);
        internal const string DragLeave = nameof(DragLeave);
        internal const string DragOver = nameof(DragOver);
        internal const string Drop = nameof(Drop);
        internal const string FocusableChanged = nameof(FocusableChanged);
        internal const string GiveFeedback = nameof(GiveFeedback);
        internal const string GotFocus = nameof(GotFocus);
        internal const string GotKeyboardFocus = nameof(GotKeyboardFocus);
        internal const string GotMouseCapture = nameof(GotMouseCapture);
        internal const string GotStylusCapture = nameof(GotStylusCapture);
        internal const string GotTouchCapture = nameof(GotTouchCapture);
        internal const string IsEnabledChanged = nameof(IsEnabledChanged);
        internal const string IsHitTestVisibleChanged = nameof(IsHitTestVisibleChanged);
        internal const string IsKeyboardFocusedChanged = nameof(IsKeyboardFocusedChanged);
        internal const string IsKeyboardFocusWithinChanged = nameof(IsKeyboardFocusWithinChanged);
        internal const string IsMouseCapturedChanged = nameof(IsMouseCapturedChanged);
        internal const string IsMouseCaptureWithinChanged = nameof(IsMouseCaptureWithinChanged);
        internal const string IsMouseDirectlyOverChanged = nameof(IsMouseDirectlyOverChanged);
        internal const string IsStylusCapturedChanged = nameof(IsStylusCapturedChanged);
        internal const string IsStylusCaptureWithinChanged = nameof(IsStylusCaptureWithinChanged);
        internal const string IsStylusDirectlyOverChanged = nameof(IsStylusDirectlyOverChanged);
        internal const string IsVisibleChanged = nameof(IsVisibleChanged);
        internal const string KeyDown = nameof(KeyDown);
        internal const string KeyUp = nameof(KeyUp);
        internal const string LayoutUpdated = nameof(LayoutUpdated);
        internal const string LostFocus = nameof(LostFocus);
        internal const string LostKeyboardFocus = nameof(LostKeyboardFocus);
        internal const string LostMouseCapture = nameof(LostMouseCapture);
        internal const string LostStylusCapture = nameof(LostStylusCapture);
        internal const string LostTouchCapture = nameof(LostTouchCapture);
        internal const string ManipulationBoundaryFeedback = nameof(ManipulationBoundaryFeedback);
        internal const string ManipulationCompleted = nameof(ManipulationCompleted);
        internal const string ManipulationDelta = nameof(ManipulationDelta);
        internal const string ManipulationInertiaStarting = nameof(ManipulationInertiaStarting);
        internal const string ManipulationStarted = nameof(ManipulationStarted);
        internal const string ManipulationStarting = nameof(ManipulationStarting);
        internal const string MouseDown = nameof(MouseDown);
        internal const string MouseEnter = nameof(MouseEnter);
        internal const string MouseLeave = nameof(MouseLeave);
        internal const string MouseLeftButtonDown = nameof(MouseLeftButtonDown);
        internal const string MouseLeftButtonUp = nameof(MouseLeftButtonUp);
        internal const string MouseMove = nameof(MouseMove);
        internal const string MouseRightButtonDown = nameof(MouseRightButtonDown);
        internal const string MouseRightButtonUp = nameof(MouseRightButtonUp);
        internal const string MouseUp = nameof(MouseUp);
        internal const string MouseWheel = nameof(MouseWheel);
        internal const string PreviewDragEnter = nameof(PreviewDragEnter);
        internal const string PreviewDragLeave = nameof(PreviewDragLeave);
        internal const string PreviewDragOver = nameof(PreviewDragOver);
        internal const string PreviewDrop = nameof(PreviewDrop);
        internal const string PreviewGiveFeedback = nameof(PreviewGiveFeedback);
        internal const string PreviewGotKeyboardFocus = nameof(PreviewGotKeyboardFocus);
        internal const string PreviewKeyDown = nameof(PreviewKeyDown);
        internal const string PreviewKeyUp = nameof(PreviewKeyUp);
        internal const string PreviewLostKeyboardFocus = nameof(PreviewLostKeyboardFocus);
        internal const string PreviewMouseDown = nameof(PreviewMouseDown);
        internal const string PreviewMouseLeftButtonDown = nameof(PreviewMouseLeftButtonDown);
        internal const string PreviewMouseLeftButtonUp = nameof(PreviewMouseLeftButtonUp);
        internal const string PreviewMouseMove = nameof(PreviewMouseMove);
        internal const string PreviewMouseRightButtonDown = nameof(PreviewMouseRightButtonDown);
        internal const string PreviewMouseRightButtonUp = nameof(PreviewMouseRightButtonUp);
        internal const string PreviewMouseUp = nameof(PreviewMouseUp);
        internal const string PreviewMouseWheel = nameof(PreviewMouseWheel);
        internal const string PreviewQueryContinueDrag = nameof(PreviewQueryContinueDrag);
        internal const string PreviewStylusButtonDown = nameof(PreviewStylusButtonDown);
        internal const string PreviewStylusButtonUp = nameof(PreviewStylusButtonUp);
        internal const string PreviewStylusDown = nameof(PreviewStylusDown);
        internal const string PreviewStylusInAirMove = nameof(PreviewStylusInAirMove);
        internal const string PreviewStylusInRange = nameof(PreviewStylusInRange);
        internal const string PreviewStylusMove = nameof(PreviewStylusMove);
        internal const string PreviewStylusOutOfRange = nameof(PreviewStylusOutOfRange);
        internal const string PreviewStylusSystemGesture = nameof(PreviewStylusSystemGesture);
        internal const string PreviewStylusUp = nameof(PreviewStylusUp);
        internal const string PreviewTextInput = nameof(PreviewTextInput);
        internal const string PreviewTouchDown = nameof(PreviewTouchDown);
        internal const string PreviewTouchMove = nameof(PreviewTouchMove);
        internal const string PreviewTouchUp = nameof(PreviewTouchUp);
        internal const string QueryContinueDrag = nameof(QueryContinueDrag);
        internal const string QueryCursor = nameof(QueryCursor);
        internal const string StylusButtonDown = nameof(StylusButtonDown);
        internal const string StylusButtonUp = nameof(StylusButtonUp);
        internal const string StylusDown = nameof(StylusDown);
        internal const string StylusEnter = nameof(StylusEnter);
        internal const string StylusInAirMove = nameof(StylusInAirMove);
        internal const string StylusInRange = nameof(StylusInRange);
        internal const string StylusLeave = nameof(StylusLeave);
        internal const string StylusMove = nameof(StylusMove);
        internal const string StylusOutOfRange = nameof(StylusOutOfRange);
        internal const string StylusSystemGesture = nameof(StylusSystemGesture);
        internal const string StylusUp = nameof(StylusUp);
        internal const string TextInput = nameof(TextInput);
        internal const string TouchDown = nameof(TouchDown);
        internal const string TouchEnter = nameof(TouchEnter);
        internal const string TouchLeave = nameof(TouchLeave);
        internal const string TouchMove = nameof(TouchMove);
        internal const string TouchUp = nameof(TouchUp);

        #endregion

        #region Methods

        /// <inheritdoc />
        public virtual T ToUIElement(ICommandProvider commandProvider = null, IList<StyleModel> styleModels = null)
        {
            T element = new T();
            //Bind properties
            BindProperties(element);

            //Bind commands
            BindCommands(element, commandProvider);

            //todo support not only grid
            //Set positions in parent grid
            Grid.SetRow(element, ParentRow);
            Grid.SetColumn(element, ParentColumn);
            Grid.SetRowSpan(element, RowSpan);
            Grid.SetColumnSpan(element, ColumnSpan);

            return element;
        }

        /// <inheritdoc />
        public virtual void BindProperties(T element, ICommandProvider commandProvider = null,
                                           IList<StyleModel> styleModels = null)
        {
            if (element == null) throw new UIException(nameof(element));

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
            bool isParsed = Enum.TryParse(Visibility, out Visibility visibility);
            element.Visibility = isParsed ? visibility : default;
        }

        /// <inheritdoc />
        public virtual void BindCommand(T element, ICommandModel commandModel, ICommandProvider commandProvider)
        {
            if (element is null) throw new UIException(nameof(element));
            if (commandModel is null) throw new UIException(nameof(commandModel));

            string eventName = commandModel.EventName;
            string methodName = commandModel.Method;
            IEnumerable<ICommandArgModel> methodArgs = commandModel.Args;

            switch (eventName)
            {
                case DragEnter:
                    {
                        element.DragEnter += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case DragLeave:
                    {
                        element.DragLeave += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case DragOver:
                    {
                        element.DragOver += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case Drop:
                    {
                        element.Drop += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case FocusableChanged:
                    {
                        element.FocusableChanged += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case GiveFeedback:
                    {
                        element.GiveFeedback += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case GotFocus:
                    {
                        element.GotFocus += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case GotKeyboardFocus:
                    {
                        element.GotKeyboardFocus += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case GotMouseCapture:
                    {
                        element.GotMouseCapture += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case GotStylusCapture:
                    {
                        element.GotStylusCapture += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case GotTouchCapture:
                    {
                        element.GotTouchCapture += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case IsEnabledChanged:
                    {
                        element.IsEnabledChanged += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case IsHitTestVisibleChanged:
                    {
                        element.IsHitTestVisibleChanged += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case IsKeyboardFocusedChanged:
                    {
                        element.IsKeyboardFocusedChanged += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case IsKeyboardFocusWithinChanged:
                    {
                        element.IsKeyboardFocusWithinChanged += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case IsMouseCapturedChanged:
                    {
                        element.IsMouseCapturedChanged += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case IsMouseCaptureWithinChanged:
                    {
                        element.IsMouseCaptureWithinChanged += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case IsMouseDirectlyOverChanged:
                    {
                        element.IsMouseDirectlyOverChanged += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case IsStylusCapturedChanged:
                    {
                        element.IsStylusCapturedChanged += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case IsStylusCaptureWithinChanged:
                    {
                        element.IsStylusCaptureWithinChanged += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case IsStylusDirectlyOverChanged:
                    {
                        element.IsStylusDirectlyOverChanged += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case IsVisibleChanged:
                    {
                        element.IsVisibleChanged += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case KeyDown:
                    {
                        element.KeyDown += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case KeyUp:
                    {
                        element.KeyUp += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case LayoutUpdated:
                    {
                        element.LayoutUpdated += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case LostFocus:
                    {
                        element.LostFocus += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case LostKeyboardFocus:
                    {
                        element.LostKeyboardFocus += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case LostMouseCapture:
                    {
                        element.LostMouseCapture += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case LostStylusCapture:
                    {
                        element.LostStylusCapture += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case LostTouchCapture:
                    {
                        element.LostTouchCapture += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case ManipulationBoundaryFeedback:
                    {
                        element.ManipulationBoundaryFeedback += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case ManipulationCompleted:
                    {
                        element.ManipulationCompleted += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case ManipulationDelta:
                    {
                        element.ManipulationDelta += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case ManipulationInertiaStarting:
                    {
                        element.ManipulationInertiaStarting += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case ManipulationStarted:
                    {
                        element.ManipulationStarted += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case ManipulationStarting:
                    {
                        element.ManipulationStarting += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case MouseDown:
                    {
                        element.MouseDown += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case MouseEnter:
                    {
                        element.MouseEnter += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case MouseLeave:
                    {
                        element.MouseLeave += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case MouseLeftButtonDown:
                    {
                        element.MouseLeftButtonDown += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case MouseLeftButtonUp:
                    {
                        element.MouseLeftButtonUp += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case MouseMove:
                    {
                        element.MouseMove += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case MouseRightButtonDown:
                    {
                        element.MouseRightButtonDown += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case MouseRightButtonUp:
                    {
                        element.MouseRightButtonUp += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case MouseUp:
                    {
                        element.MouseUp += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case MouseWheel:
                    {
                        element.MouseWheel += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewDragEnter:
                    {
                        element.PreviewDragEnter += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewDragLeave:
                    {
                        element.PreviewDragLeave += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewDragOver:
                    {
                        element.PreviewDragOver += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewDrop:
                    {
                        element.PreviewDrop += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewGiveFeedback:
                    {
                        element.PreviewGiveFeedback += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewGotKeyboardFocus:
                    {
                        element.PreviewGotKeyboardFocus += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewKeyDown:
                    {
                        element.PreviewKeyDown += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewKeyUp:
                    {
                        element.PreviewKeyUp += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewLostKeyboardFocus:
                    {
                        element.PreviewLostKeyboardFocus += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewMouseDown:
                    {
                        element.PreviewMouseDown += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewMouseLeftButtonDown:
                    {
                        element.PreviewMouseLeftButtonDown += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewMouseLeftButtonUp:
                    {
                        element.PreviewMouseLeftButtonUp += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewMouseMove:
                    {
                        element.PreviewMouseMove += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewMouseRightButtonDown:
                    {
                        element.PreviewMouseRightButtonDown += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewMouseRightButtonUp:
                    {
                        element.PreviewMouseRightButtonUp += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewMouseUp:
                    {
                        element.PreviewMouseUp += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewMouseWheel:
                    {
                        element.PreviewMouseWheel += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewQueryContinueDrag:
                    {
                        element.PreviewQueryContinueDrag += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewStylusButtonDown:
                    {
                        element.PreviewStylusButtonDown += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewStylusButtonUp:
                    {
                        element.PreviewStylusButtonUp += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewStylusDown:
                    {
                        element.PreviewStylusDown += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewStylusInAirMove:
                    {
                        element.PreviewStylusInAirMove += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewStylusInRange:
                    {
                        element.PreviewStylusInRange += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewStylusMove:
                    {
                        element.PreviewStylusMove += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewStylusOutOfRange:
                    {
                        element.PreviewStylusOutOfRange += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewStylusSystemGesture:
                    {
                        element.PreviewStylusSystemGesture += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewStylusUp:
                    {
                        element.PreviewStylusUp += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewTextInput:
                    {
                        element.PreviewTextInput += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewTouchDown:
                    {
                        element.PreviewTouchDown += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewTouchMove:
                    {
                        element.PreviewTouchMove += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case PreviewTouchUp:
                    {
                        element.PreviewTouchUp += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case QueryContinueDrag:
                    {
                        element.QueryContinueDrag += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case QueryCursor:
                    {
                        element.QueryCursor += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case StylusButtonDown:
                    {
                        element.StylusButtonDown += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case StylusButtonUp:
                    {
                        element.StylusButtonUp += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case StylusDown:
                    {
                        element.StylusDown += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case StylusEnter:
                    {
                        element.StylusEnter += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case StylusInAirMove:
                    {
                        element.StylusInAirMove += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case StylusInRange:
                    {
                        element.StylusInRange += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case StylusLeave:
                    {
                        element.StylusLeave += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case StylusMove:
                    {
                        element.StylusMove += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case StylusOutOfRange:
                    {
                        element.StylusOutOfRange += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case StylusSystemGesture:
                    {
                        element.StylusSystemGesture += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case StylusUp:
                    {
                        element.StylusUp += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case TextInput:
                    {
                        element.TextInput += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case TouchDown:
                    {
                        element.TouchDown += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case TouchEnter:
                    {
                        element.TouchEnter += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case TouchLeave:
                    {
                        element.TouchLeave += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case TouchMove:
                    {
                        element.TouchMove += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case TouchUp:
                    {
                        element.TouchUp += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

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
        public virtual void BindCommands(T element, ICommandProvider commandProvider)
        {
            foreach (ICommandModel commandModel in Commands)
                BindCommand(element, commandModel, commandProvider);
        }

        #endregion
    }
}
