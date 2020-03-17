using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Jaml.Wpf.Constants;
using Jaml.Wpf.Models.CommandModels;

namespace Jaml.Wpf.Providers.CommandProvider
{
    // ReSharper disable once ClassCanBeSealed.Global

    /// <inheritdoc />
    public class CommandProvider : ICommandProvider
    {
        #region Properties

        /// <inheritdoc />
        public Dictionary<string, Action<object, IEnumerable<CommandArgModel>>> Commands { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new <see cref="CommandProvider"/> with specified commands
        /// </summary>
        /// <param name="commands">Commands for this provider</param>
        public CommandProvider(Dictionary<string, Action<object, IEnumerable<CommandArgModel>>> commands) => Commands = commands;

        /// <summary>
        /// Creates a new <see cref="CommandProvider"/> with empty dictionary of commands
        /// </summary>
        public CommandProvider() => Commands = new Dictionary<string, Action<object, IEnumerable<CommandArgModel>>>();

        #endregion

        #region Methods

        /// <inheritdoc />
        public void RegisterCommands(Dictionary<string, Action<object, IEnumerable<CommandArgModel>>> commands)
        {
            foreach ((string commandName, Action<object, IEnumerable<CommandArgModel>> command) in commands)
                RegisterCommand(commandName, command);
        }

        /// <inheritdoc />
        public void UnregisterCommands(IEnumerable<string> commandNames)
        {
            foreach (string commandName in commandNames) UnregisterCommand(commandName);
        }

        /// <inheritdoc />
        public void ClearCommands() => Commands.Clear();

        /// <inheritdoc />
        public void RegisterCommand(string commandName, Action<object, IEnumerable<CommandArgModel>> command) =>
            Commands.TryAdd(commandName, command);

        /// <inheritdoc />
        public void UnregisterCommand(string commandName) => Commands.Remove(commandName);

        /// <inheritdoc />
        public void RunCommand(string commandName, object sender, IEnumerable<CommandArgModel> args)
        {
            if (string.IsNullOrWhiteSpace(commandName)) return;
            if (!Commands.ContainsKey(commandName)) return;

            //GetCommand(commandName).DynamicInvoke(sender, args);
            GetCommand(commandName).Invoke(sender, args);
        }

        /// <inheritdoc />
        public Action<object, IEnumerable<CommandArgModel>> GetCommand(string commandName)
        {
            Commands.TryGetValue(commandName, out Action<object, IEnumerable<CommandArgModel>> value);

            return value;
        }

        /// <inheritdoc />
        public void BindCommand<T>(ref T element, ICommandModel commandModel) where T : UIElement
        {
            //todo use reflection, this is ugly

            string eventName = commandModel.Event;
            string methodName = commandModel.Method;
            IEnumerable<CommandArgModel> methodArgs = commandModel.Args;

            switch (eventName)
            {
                #region UIElement

                case EventNames.DragEnter:
                    {
                        element.DragEnter += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.DragLeave:
                    {
                        element.DragLeave += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.DragOver:
                    {
                        element.DragOver += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.Drop:
                    {
                        element.Drop += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.FocusableChanged:
                    {
                        element.FocusableChanged += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.GiveFeedback:
                    {
                        element.GiveFeedback += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.GotFocus:
                    {
                        element.GotFocus += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.GotKeyboardFocus:
                    {
                        element.GotKeyboardFocus += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.GotMouseCapture:
                    {
                        element.GotMouseCapture += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.GotStylusCapture:
                    {
                        element.GotStylusCapture += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.GotTouchCapture:
                    {
                        element.GotTouchCapture += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.IsEnabledChanged:
                    {
                        element.IsEnabledChanged += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.IsHitTestVisibleChanged:
                    {
                        element.IsHitTestVisibleChanged += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.IsKeyboardFocusedChanged:
                    {
                        element.IsKeyboardFocusedChanged += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.IsKeyboardFocusWithinChanged:
                    {
                        element.IsKeyboardFocusWithinChanged += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.IsMouseCapturedChanged:
                    {
                        element.IsMouseCapturedChanged += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.IsMouseCaptureWithinChanged:
                    {
                        element.IsMouseCaptureWithinChanged += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.IsMouseDirectlyOverChanged:
                    {
                        element.IsMouseDirectlyOverChanged += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.IsStylusCapturedChanged:
                    {
                        element.IsStylusCapturedChanged += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.IsStylusCaptureWithinChanged:
                    {
                        element.IsStylusCaptureWithinChanged += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.IsStylusDirectlyOverChanged:
                    {
                        element.IsStylusDirectlyOverChanged += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.IsVisibleChanged:
                    {
                        element.IsVisibleChanged += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.KeyDown:
                    {
                        element.KeyDown += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.KeyUp:
                    {
                        element.KeyUp += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.LayoutUpdated:
                    {
                        element.LayoutUpdated += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.LostFocus:
                    {
                        element.LostFocus += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.LostKeyboardFocus:
                    {
                        element.LostKeyboardFocus += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.LostMouseCapture:
                    {
                        element.LostMouseCapture += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.LostStylusCapture:
                    {
                        element.LostStylusCapture += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.LostTouchCapture:
                    {
                        element.LostTouchCapture += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.ManipulationBoundaryFeedback:
                    {
                        element.ManipulationBoundaryFeedback += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.ManipulationCompleted:
                    {
                        element.ManipulationCompleted += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.ManipulationDelta:
                    {
                        element.ManipulationDelta += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.ManipulationInertiaStarting:
                    {
                        element.ManipulationInertiaStarting += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.ManipulationStarted:
                    {
                        element.ManipulationStarted += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.ManipulationStarting:
                    {
                        element.ManipulationStarting += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.MouseDown:
                    {
                        element.MouseDown += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.MouseEnter:
                    {
                        element.MouseEnter += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.MouseLeave:
                    {
                        element.MouseLeave += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.MouseLeftButtonDown:
                    {
                        element.MouseLeftButtonDown += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.MouseLeftButtonUp:
                    {
                        element.MouseLeftButtonUp += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.MouseMove:
                    {
                        element.MouseMove += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.MouseRightButtonDown:
                    {
                        element.MouseRightButtonDown += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.MouseRightButtonUp:
                    {
                        element.MouseRightButtonUp += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.MouseUp:
                    {
                        element.MouseUp += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.MouseWheel:
                    {
                        element.MouseWheel += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewDragEnter:
                    {
                        element.PreviewDragEnter += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewDragLeave:
                    {
                        element.PreviewDragLeave += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewDragOver:
                    {
                        element.PreviewDragOver += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewDrop:
                    {
                        element.PreviewDrop += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewGiveFeedback:
                    {
                        element.PreviewGiveFeedback += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewGotKeyboardFocus:
                    {
                        element.PreviewGotKeyboardFocus += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewKeyDown:
                    {
                        element.PreviewKeyDown += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewKeyUp:
                    {
                        element.PreviewKeyUp += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewLostKeyboardFocus:
                    {
                        element.PreviewLostKeyboardFocus += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewMouseDown:
                    {
                        element.PreviewMouseDown += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewMouseLeftButtonDown:
                    {
                        element.PreviewMouseLeftButtonDown += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewMouseLeftButtonUp:
                    {
                        element.PreviewMouseLeftButtonUp += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewMouseMove:
                    {
                        element.PreviewMouseMove += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewMouseRightButtonDown:
                    {
                        element.PreviewMouseRightButtonDown += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewMouseRightButtonUp:
                    {
                        element.PreviewMouseRightButtonUp += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewMouseUp:
                    {
                        element.PreviewMouseUp += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewMouseWheel:
                    {
                        element.PreviewMouseWheel += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewQueryContinueDrag:
                    {
                        element.PreviewQueryContinueDrag += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewStylusButtonDown:
                    {
                        element.PreviewStylusButtonDown += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewStylusButtonUp:
                    {
                        element.PreviewStylusButtonUp += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewStylusDown:
                    {
                        element.PreviewStylusDown += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewStylusInAirMove:
                    {
                        element.PreviewStylusInAirMove += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewStylusInRange:
                    {
                        element.PreviewStylusInRange += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewStylusMove:
                    {
                        element.PreviewStylusMove += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewStylusOutOfRange:
                    {
                        element.PreviewStylusOutOfRange += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewStylusSystemGesture:
                    {
                        element.PreviewStylusSystemGesture += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewStylusUp:
                    {
                        element.PreviewStylusUp += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewTextInput:
                    {
                        element.PreviewTextInput += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewTouchDown:
                    {
                        element.PreviewTouchDown += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewTouchMove:
                    {
                        element.PreviewTouchMove += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.PreviewTouchUp:
                    {
                        element.PreviewTouchUp += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.QueryContinueDrag:
                    {
                        element.QueryContinueDrag += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.QueryCursor:
                    {
                        element.QueryCursor += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.StylusButtonDown:
                    {
                        element.StylusButtonDown += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.StylusButtonUp:
                    {
                        element.StylusButtonUp += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.StylusDown:
                    {
                        element.StylusDown += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.StylusEnter:
                    {
                        element.StylusEnter += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.StylusInAirMove:
                    {
                        element.StylusInAirMove += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.StylusInRange:
                    {
                        element.StylusInRange += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.StylusLeave:
                    {
                        element.StylusLeave += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.StylusMove:
                    {
                        element.StylusMove += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.StylusOutOfRange:
                    {
                        element.StylusOutOfRange += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.StylusSystemGesture:
                    {
                        element.StylusSystemGesture += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.StylusUp:
                    {
                        element.StylusUp += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.TextInput:
                    {
                        element.TextInput += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.TouchDown:
                    {
                        element.TouchDown += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.TouchEnter:
                    {
                        element.TouchEnter += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.TouchLeave:
                    {
                        element.TouchLeave += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.TouchMove:
                    {
                        element.TouchMove += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.TouchUp:
                    {
                        element.TouchUp += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }

                #endregion

                #region FrameworkElement

                case EventNames.ContextMenuClosing:
                    {
                        if (element is FrameworkElement frameworkElement)
                            frameworkElement.ContextMenuClosing += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.ContextMenuOpening:
                    {
                        if (element is FrameworkElement frameworkElement)
                            frameworkElement.ContextMenuOpening += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.DataContextChanged:
                    {
                        if (element is FrameworkElement frameworkElement)
                            frameworkElement.DataContextChanged += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.Initialized:
                    {
                        if (element is FrameworkElement frameworkElement)
                            frameworkElement.Initialized += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.Loaded:
                    {
                        if (element is FrameworkElement frameworkElement)
                            frameworkElement.Loaded += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.RequestBringIntoView:
                    {
                        if (element is FrameworkElement frameworkElement)
                            frameworkElement.RequestBringIntoView += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.SizeChanged:
                    {
                        if (element is FrameworkElement frameworkElement)
                            frameworkElement.SizeChanged += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.SourceUpdated:
                    {
                        if (element is FrameworkElement frameworkElement)
                            frameworkElement.SourceUpdated += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.TargetUpdated:
                    {
                        if (element is FrameworkElement frameworkElement)
                            frameworkElement.TargetUpdated += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.ToolTipClosing:
                    {
                        if (element is FrameworkElement frameworkElement)
                            frameworkElement.ToolTipClosing += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.ToolTipOpening:
                    {
                        if (element is FrameworkElement frameworkElement)
                            frameworkElement.ToolTipOpening += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }

                case EventNames.Unloaded:
                    {
                        if (element is FrameworkElement frameworkElement)
                            frameworkElement.Unloaded += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }

                #endregion

                #region ButtonBase

                case EventNames.Click:
                    {
                        if (element is ButtonBase button)
                            button.Click += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }

                #endregion

                #region MediaElement

                case EventNames.BufferingEnded:
                    {
                        if (element is MediaElement mediaElement)
                            mediaElement.BufferingEnded += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.BufferingStarted:
                    {
                        if (element is MediaElement mediaElement)
                            mediaElement.BufferingStarted += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.MediaEnded:
                    {
                        if (element is MediaElement mediaElement)
                            mediaElement.MediaEnded += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.MediaFailed:
                    {
                        if (element is MediaElement mediaElement)
                            mediaElement.MediaFailed += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.MediaOpened:
                    {
                        if (element is MediaElement mediaElement)
                            mediaElement.MediaOpened += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case EventNames.ScriptCommand:
                    {
                        if (element is MediaElement mediaElement)
                            mediaElement.ScriptCommand += (sender, args) => RunCommand(methodName, sender, methodArgs);

                        break;
                    }

                #endregion

                default: { throw new NotSupportedException($"Event {eventName} is not supported."); }
            }
        }

        /// <inheritdoc />
        public void BindCommands<T>(ref T element, IEnumerable<ICommandModel> commandModels) where T : UIElement
        {
            foreach (ICommandModel commandModel in commandModels) BindCommand(ref element, commandModel);
        }

        #endregion
    }
}
