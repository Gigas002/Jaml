﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Jaml.Wpf.Helpers;
using Jaml.Wpf.Parsers;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace Jaml.Wpf.Models.StyleModels
{
    // ReSharper disable once ClassNeverInstantiated.Global

    /// <summary>
    /// Basic class, that implements the <see cref="IStyleModel" />
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
        public string Background { get; set; } = null;

        /// <inheritdoc />
        [JsonPropertyName("BorderThickness")]
        public double BorderThickness { get; set; } = 1.0;

        /// <inheritdoc />
        [JsonPropertyName("Visibility")]
        public string Visibility { get; set; } = null;

        #endregion

        /// <inheritdoc />
        public T ToStyle<T>() where T : Style, new()
        {
            //todo improve this ugly code?
            T style = new T();

            FontWeight fontWeight = PropertyParser.ParseFontWeight(FontWeight);
            FontStyle fontStyle = PropertyParser.ParseFontStyle(FontStyle);
            Brush foreground = PropertyParser.ConvertArgbToBrush(Foreground);
            Brush background = PropertyParser.ParseBackground(Background);
            Thickness borderThickness = new Thickness(BorderThickness);
            bool isParsed = Enum.TryParse(Visibility, out Visibility visibility);
            visibility = isParsed ? visibility : default;

            style.Setters.Add(new Setter { Property = Control.FontWeightProperty, Value = fontWeight });
            style.Setters.Add(new Setter { Property = Control.FontStyleProperty, Value = fontStyle });
            style.Setters.Add(new Setter { Property = Control.FontSizeProperty, Value = FontSize });
            style.Setters.Add(new Setter { Property = Control.ForegroundProperty, Value = foreground });
            style.Setters.Add(new Setter { Property = Control.BackgroundProperty, Value = background });
            style.Setters.Add(new Setter { Property = Control.BorderThicknessProperty, Value = borderThickness });
            style.Setters.Add(new Setter { Property = UIElement.VisibilityProperty, Value = visibility });

            if (string.IsNullOrWhiteSpace(FontFamily)) return style;

            style.Setters.Add(new Setter
            {
                Property = Control.FontFamilyProperty,
                Value = new FontFamily(PathsHelper.GetUriFromRelativePath(FontFamily), string.Empty)
            });

            return style;
        }

        /// <summary>
        /// Get style model by id from collection
        /// </summary>
        /// <param name="styleModels"></param>
        /// <param name="styleId"></param>
        /// <returns></returns>
        public static IStyleModel TryGetStyleModel(IEnumerable<StyleModel> styleModels, int styleId) =>
            styleModels?.FirstOrDefault(sm => sm.Id == styleId);

        /// <summary>
        /// Get style from stylemodel collection by id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="styleModels"></param>
        /// <param name="styleId"></param>
        /// <returns></returns>
        public static T TryGetStyle<T>(IEnumerable<StyleModel> styleModels, int styleId) where T : Style, new() =>
            TryGetStyleModel(styleModels, styleId)?.ToStyle<T>();
    }
}
