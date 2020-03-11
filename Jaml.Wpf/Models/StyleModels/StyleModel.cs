using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Jaml.Wpf.Helpers;
using Jaml.Wpf.Models.UIElementModels;
using Jaml.Wpf.Parsers;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace Jaml.Wpf.Models.StyleModels
{
    // ReSharper disable once ClassNeverInstantiated.Global

    /// <summary>
    /// Basic class, that implements the <see cref="T:Jaml.Wpf.Models.StyleModels.IStyleModel" />
    /// </summary>
    public class StyleModel : IStyleModel
    {
        #region Json Properties

        /// <inheritdoc />
        [JsonPropertyName("Id")]
        public int Id { get; set; } = -1;

        /// <inheritdoc />
        [JsonPropertyName("FontSize")]
        public double FontSize { get; set; } = 20.0;

        /// <inheritdoc />
        [JsonPropertyName("FontFamily")]
        public string FontFamily { get; set; } = null;

        /// <inheritdoc />
        [JsonPropertyName("FontStyle")]
        public string FontStyle { get; set; } = null;

        /// <inheritdoc />
        [JsonPropertyName("FontWeight")]
        public string FontWeight { get; set; } = null;

        /// <inheritdoc />
        [JsonPropertyName("Foreground")]
        public string Foreground { get; set; } = null;

        /// <inheritdoc />
        [JsonPropertyName("Background")]
        public BackgroundModel Background { get; set; } = null;

        /// <inheritdoc />
        [JsonPropertyName("BorderThickness")]
        public double BorderThickness { get; set; } = 1.0;

        /// <inheritdoc />
        [JsonPropertyName("Visibility")]
        public string Visibility { get; set; } = null;

        #endregion

        /// <inheritdoc />
        public void ToStyle<T>(ref T style) where T : Style
        {
            //todo improve this ugly code?

            FontWeight fontWeight = PropertyParser.ParseFontWeight(FontWeight);
            FontStyle fontStyle = PropertyParser.ParseFontStyle(FontStyle);
            Brush foreground = PropertyParser.ConvertArgbToBrush(Foreground);
            Brush background = PropertyParser.ParseBackground(Background);
            Thickness borderThickness = PropertyParser.ParseThickness(BorderThickness);
            Visibility visibility = PropertyParser.ParseVisibility(Visibility);

            style.Setters.Add(new Setter { Property = Control.FontWeightProperty, Value = fontWeight });
            style.Setters.Add(new Setter { Property = Control.FontStyleProperty, Value = fontStyle });
            style.Setters.Add(new Setter { Property = Control.FontSizeProperty, Value = FontSize });
            style.Setters.Add(new Setter { Property = Control.ForegroundProperty, Value = foreground });
            style.Setters.Add(new Setter { Property = Control.BackgroundProperty, Value = background });
            style.Setters.Add(new Setter { Property = Control.BorderThicknessProperty, Value = borderThickness });
            style.Setters.Add(new Setter { Property = UIElement.VisibilityProperty, Value = visibility });

            if (string.IsNullOrWhiteSpace(FontFamily)) return;

            style.Setters.Add(new Setter
            {
                Property = Control.FontFamilyProperty,
                Value = new FontFamily(PathsHelper.GetUriFromRelativePath(FontFamily), string.Empty)
            });
        }
    }
}
