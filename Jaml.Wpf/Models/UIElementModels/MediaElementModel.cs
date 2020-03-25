using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows.Controls;
using System.Windows.Media;
using Jaml.Wpf.Helpers;
using Jaml.Wpf.Models.CommandModels;
using Jaml.Wpf.Providers.CommandProvider;
using Jaml.Wpf.Providers.StyleProvider;

namespace Jaml.Wpf.Models.UIElementModels
{
    // ReSharper disable once ClassNeverInstantiated.Global

    /// <summary>
    /// Model of media elements, like video or audio
    /// </summary>
    /// <typeparam name="T">Children of <see cref="MediaElement"/></typeparam>
    public class MediaElementModel<T> : FrameworkElementModel<T>, IUIElementModel<T> where T : MediaElement, new()
    {
        #region Properties

        /// <summary>
        /// Balance
        /// </summary>
        [JsonPropertyName("Balance")]
        public double Balance { get; set; } = 0.0;

        /// <summary>
        /// Is muted
        /// </summary>
        [JsonPropertyName("IsMuted")]
        public bool IsMuted { get; set; } = false;

        /// <summary>
        /// Position
        /// </summary>
        [JsonPropertyName("Position")]
        public string Position { get; set; } = "00:00:00";

        /// <summary>
        /// Scrubbing enabled
        /// </summary>
        [JsonPropertyName("ScrubbingEnabled")]
        public bool ScrubbingEnabled { get; set; } = false;

        /// <summary>
        /// Element's content
        /// </summary>
        [JsonPropertyName("Source")]
        public string Source { get; set; } = string.Empty;

        /// <summary>
        /// Speed ratio
        /// </summary>
        [JsonPropertyName("SpeedRatio")]
        public double SpeedRatio { get; set; } = 1.0;

        /// <summary>
        /// Volume
        /// </summary>
        [JsonPropertyName("Volume")]
        public double Volume { get; set; } = 0.5;

        #region WIP

        /// <summary>
        /// 
        /// </summary>
        public MediaClock Clock { get; } = null;

        /// <summary>
        /// 
        /// </summary>
        public Stretch Stretch { get; } = Stretch.Uniform;

        /// <summary>
        /// 
        /// </summary>
        public StretchDirection StretchDirection { get; } = StretchDirection.Both;

        #endregion

        #region Non-json properties

        private MediaState LoadedBehavior { get; } = MediaState.Manual;

        private MediaState UnloadedBehavior { get; } = MediaState.Close;

        #endregion

        #endregion

        #region EventNames

        internal const string BufferingEnded = nameof(BufferingEnded);
        internal const string BufferingStarted = nameof(BufferingStarted);
        internal const string MediaEnded = nameof(MediaEnded);
        internal const string MediaFailed = nameof(MediaFailed);
        internal const string MediaOpened = nameof(MediaOpened);
        internal const string ScriptCommand = nameof(ScriptCommand);

        #endregion

        /// <inheritdoc />
        public override T ToUIElement(ICommandProvider commandProvider, IStyleProvider styleProvider)
        {
            T element = base.ToUIElement(commandProvider, styleProvider);

            BindProperties(element);

            return element;
        }

        /// <inheritdoc />
        public new void BindProperties(T element, ICommandProvider commandProvider = null,
                                       IStyleProvider styleProvider = null)
        {
            element.Balance = Balance;
            element.Clock = Clock;
            element.IsMuted = IsMuted;
            element.LoadedBehavior = LoadedBehavior;

            TimeSpan.TryParse(Position, out TimeSpan positionTimeSpan);
            element.Position = positionTimeSpan;

            element.ScrubbingEnabled = ScrubbingEnabled;

            if (!string.IsNullOrWhiteSpace(Source))
                element.Source = PathsHelper.GetUriFromRelativePath(Source);

            element.SpeedRatio = SpeedRatio;
            element.Stretch = Stretch;
            element.StretchDirection = StretchDirection;
            element.UnloadedBehavior = UnloadedBehavior;
            element.Volume = Volume;
        }

        /// <inheritdoc />
        public new void BindCommand(T element, ICommandModel commandModel, ICommandProvider commandProvider)
        {
            string eventName = commandModel.Event;
            string methodName = commandModel.Method;
            IEnumerable<ICommandArgModel> methodArgs = commandModel.Args;

            switch (eventName)
            {
                case BufferingEnded:
                    {
                        if (element is MediaElement mediaElement)
                            mediaElement.BufferingEnded += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case BufferingStarted:
                    {
                        if (element is MediaElement mediaElement)
                            mediaElement.BufferingStarted += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case MediaEnded:
                    {
                        if (element is MediaElement mediaElement)
                            mediaElement.MediaEnded += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case MediaFailed:
                    {
                        if (element is MediaElement mediaElement)
                            mediaElement.MediaFailed += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case MediaOpened:
                    {
                        if (element is MediaElement mediaElement)
                            mediaElement.MediaOpened += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                        break;
                    }
                case ScriptCommand:
                    {
                        if (element is MediaElement mediaElement)
                            mediaElement.ScriptCommand += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

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
    }
}
