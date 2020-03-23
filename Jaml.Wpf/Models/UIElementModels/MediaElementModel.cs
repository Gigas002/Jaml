using System;
using System.Text.Json.Serialization;
using System.Windows.Controls;
using System.Windows.Media;
using Jaml.Wpf.Helpers;
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

        /// <inheritdoc />
        public override T ToUIElement(ICommandProvider commandProvider, IStyleProvider styleProvider)
        {
            T element = base.ToUIElement(commandProvider, styleProvider);

            BindProperties(element, null, null);

            return element;
        }

        /// <inheritdoc />
        public new void BindProperties(T element, ICommandProvider commandProvider, IStyleProvider styleProvider)
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
    }
}
