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
    public class MediaElementModel : FrameworkElementModel
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

        /// <summary>
        /// Creates media element from model
        /// </summary>
        /// <typeparam name="T">Children of <see cref="MediaElement"/></typeparam>
        /// <param name="mediaElement">Target media element</param>
        /// <param name="commandProvider">Command provider</param>
        /// <param name="styleProvider">Style provider</param>
        public void ToMediaElement<T>(ref T mediaElement, ICommandProvider commandProvider,
                                      IStyleProvider styleProvider) where T : MediaElement
        {
            //Bind styles
            styleProvider.BindStyle(ref mediaElement, StyleId);

            //Explicitly initialized properties should override styles

            //Bind properties
            BindProperties(ref mediaElement, commandProvider, styleProvider);
        }

        /// <summary>
        /// Binds model properies from model to passed element
        /// </summary>
        /// <typeparam name="T">Children of <see cref="MediaElement"/></typeparam>
        /// <param name="element">Element to take properties</param>
        /// <param name="commandProvider">Command provider</param>
        /// <param name="styleProvider">Style provider</param>
        public new void BindProperties<T>(ref T element, ICommandProvider commandProvider, IStyleProvider styleProvider) where T : MediaElement
        {
            base.BindProperties(ref element, commandProvider, styleProvider);

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
