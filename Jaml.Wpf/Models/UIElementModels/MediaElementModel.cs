using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows.Controls;
using System.Windows.Media;
using Jaml.Wpf.Exceptions;
using Jaml.Wpf.Helpers;
using Jaml.Wpf.Models.CommandModels;
using Jaml.Wpf.Models.StyleModels;
using Jaml.Wpf.Providers.CommandProviders;

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

        #region TODO

        /// <summary>
        /// 
        /// </summary>
        public MediaClock Clock { get; }

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
        public override T ToUIElement(ICommandProvider commandProvider = null, IList<StyleModel> styleModels = null)
        {
            T element = base.ToUIElement(commandProvider, styleModels);

            BindProperties(element);

            BindCommands(element, commandProvider);

            return element;
        }

        /// <inheritdoc />
        public new void BindProperties(T element, ICommandProvider commandProvider = null,
                                       IList<StyleModel> styleModels = null)
        {
            if (element is null) throw new UIException(nameof(element));

            element.Balance = Balance;
            element.Clock = Clock;
            element.IsMuted = IsMuted;
            element.LoadedBehavior = LoadedBehavior;

            bool isParsed = TimeSpan.TryParse(Position, out TimeSpan positionTimeSpan);
            element.Position = isParsed ? positionTimeSpan : default;

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
            if (element is null) throw new UIException(nameof(element));
            if (commandModel is null) throw new UIException(nameof(commandModel));

            string eventName = commandModel.EventName;
            string methodName = commandModel.Method;
            IEnumerable<ICommandArgModel> methodArgs = commandModel.Args;

            switch (eventName)
            {
                case BufferingEnded:
                {
                    element.BufferingEnded += (sender, args) =>
                        commandProvider.RunCommand(methodName, sender, methodArgs);

                    break;
                }
                case BufferingStarted:
                {
                    element.BufferingStarted += (sender, args) =>
                        commandProvider.RunCommand(methodName, sender, methodArgs);

                    break;
                }
                case MediaEnded:
                {
                    element.MediaEnded += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                    break;
                }
                case MediaFailed:
                {
                    element.MediaFailed += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                    break;
                }
                case MediaOpened:
                {
                    element.MediaOpened += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                    break;
                }
                case ScriptCommand:
                {
                    element.ScriptCommand += (sender, args) =>
                        commandProvider.RunCommand(methodName, sender, methodArgs);

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
