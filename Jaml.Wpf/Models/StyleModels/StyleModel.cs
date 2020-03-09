﻿using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Jaml.Wpf.Helpers;
using Jaml.Wpf.Models.UiElementModels;
using Jaml.Wpf.Parsers;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace Jaml.Wpf.Models.StyleModels
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class StyleModel : IStyleModel
    {
        #region Json Properties

        [JsonPropertyName("Id")]
        public int Id { get; set; } = -1;

        [JsonPropertyName("FontSize")]
        public double FontSize { get; set; } = 20.0;

        [JsonPropertyName("FontFamily")]
        public string FontFamily { get; set; } = null;

        [JsonPropertyName("FontStyle")]
        public string FontStyle { get; set; } = null;

        [JsonPropertyName("FontWeight")]
        public string FontWeight { get; set; } = null;

        [JsonPropertyName("Foreground")]
        public string Foreground { get; set; } = null;

        [JsonPropertyName("Background")]
        public BackgroundModel Background { get; set; } = null;

        [JsonPropertyName("BorderThickness")]
        public double BorderThickness { get; set; } = 1.0;

        [JsonPropertyName("Visibility")]
        public string Visibility { get; set; } = null;

        #endregion

        public Style ToStyle()
        {
            Style style = new Style();

            FontWeight fontWeight = PropertyParser.ParseFontWeight(FontWeight);
            FontStyle fontStyle = PropertyParser.ParseFontStyle(FontStyle);
            Brush foreground = PropertyParser.ConvertArgbToBrush(Foreground);
            Brush background = PropertyParser.ParseBackground(Background);
            Thickness borderThickness = PropertyParser.ParseThickness(BorderThickness);
            Visibility visibility = PropertyParser.ParseVisibility(Visibility);

            if (!string.IsNullOrWhiteSpace(FontFamily))
            {
                style.Setters.Add(new Setter
                {
                    Property = Control.FontFamilyProperty,
                    Value =
                        new
                            FontFamily(PathsHelper.GetUriFromRelativePath(FontFamily),
                                       string.Empty)
                });
            }

            style.Setters.Add(new Setter { Property = Control.FontWeightProperty, Value = fontWeight });
            style.Setters.Add(new Setter { Property = Control.FontStyleProperty, Value = fontStyle });
            style.Setters.Add(new Setter { Property = Control.FontSizeProperty, Value = FontSize });
            style.Setters.Add(new Setter { Property = Control.ForegroundProperty, Value = foreground });
            style.Setters.Add(new Setter { Property = Control.BackgroundProperty, Value = background });
            style.Setters.Add(new Setter { Property = Control.BorderThicknessProperty, Value = borderThickness });
            style.Setters.Add(new Setter { Property = UIElement.VisibilityProperty, Value = visibility });

            return style;
        }

        public void BindStyle(FrameworkElement element) => element.Style = ToStyle();
    }
}