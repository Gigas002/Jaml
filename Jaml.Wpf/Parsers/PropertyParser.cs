﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Jaml.Wpf.Helpers;

namespace Jaml.Wpf.Parsers
{
    //todo move strings to constants
    /// <summary>
    /// Contains static method to parse different <see cref="UIElement"/>'s properties
    /// </summary>
    public static class PropertyParser
    {
        /// <summary>
        /// Parse the <see cref="FontWeight"/> from string
        /// </summary>
        /// <param name="fontWeight">Font weight string</param>
        /// <returns>Parsed <see cref="FontWeight"/></returns>
        public static FontWeight ParseFontWeight(string fontWeight) => fontWeight switch
        {
            "Bold" => FontWeights.Bold,
            "Black" => FontWeights.Black,
            "DemiBold" => FontWeights.DemiBold,
            "ExtraBlack" => FontWeights.ExtraBlack,
            "ExtraBold" => FontWeights.ExtraBold,
            "ExtraLight" => FontWeights.ExtraLight,
            "Heavy" => FontWeights.Heavy,
            "Light" => FontWeights.Light,
            "Medium" => FontWeights.Medium,
            "Normal" => FontWeights.Normal,
            "SemiBold" => FontWeights.SemiBold,
            "Thin" => FontWeights.Thin,
            "UltraBlack" => FontWeights.UltraBlack,
            "UltraBold" => FontWeights.UltraBold,
            "UltraLight" => FontWeights.UltraLight,
            _ => FontWeights.Regular
        };

        /// <summary>
        /// Parse the <see cref="FontStyle"/> from string
        /// </summary>
        /// <param name="fontStyle">Font style string</param>
        /// <returns>Parsed <see cref="FontStyle"/></returns>
        public static FontStyle ParseFontStyle(string fontStyle) => fontStyle switch
        {
            "Italic" => FontStyles.Italic,
            "Oblique" => FontStyles.Oblique,
            _ => FontStyles.Normal
        };

        /// <summary>
        /// Converts the argb string to <see cref="Brush"/>
        /// </summary>
        /// <param name="argbString">argb string (e.g. 255,100,100,100)</param>
        /// <returns>Parsed <see cref="Brush"/></returns>
        public static Brush ConvertArgbToBrush(string argbString)
        {
            if (string.IsNullOrWhiteSpace(argbString)) return new SolidColorBrush(Colors.White);

            string[] argb = argbString.Trim().Replace(" ", string.Empty, StringComparison.InvariantCulture).Split(',');

            bool isParsed = byte.TryParse(argb[0], out byte a);
            a = isParsed ? a : default;
            isParsed = byte.TryParse(argb[1], out byte r);
            r = isParsed ? r : default;
            isParsed = byte.TryParse(argb[2], out byte g);
            g = isParsed ? g : default;
            isParsed = byte.TryParse(argb[3], out byte b);
            b = isParsed ? b : default;

            return new SolidColorBrush(Color.FromArgb(a, r, g, b));
        }

        /// <summary>
        /// Convert background string to brush
        /// </summary>
        public static Brush ParseBackground(string background)
        {
            if (string.IsNullOrWhiteSpace(background)) return Brushes.Transparent;

            return File.Exists(Path.GetFullPath(background)) ? UIHelper.GetBrushFromImage(background) : ConvertArgbToBrush(background);
        }

        /// <summary>
        /// Convert collection of strings to collection of column definitions
        /// </summary>
        /// <param name="columnDefinitions">Collection of column definition strings</param>
        /// <returns>collection of column definitions</returns>
        public static IEnumerable<ColumnDefinition> ParseColumnDefinitions(IEnumerable<string> columnDefinitions) =>
            columnDefinitions.Select(ParseColumnDefinition);

        /// <summary>
        /// Convert the column definition string to column definition
        /// </summary>
        /// <param name="columnDefinition">Column definition string</param>
        /// <returns>Column definition</returns>
        public static ColumnDefinition ParseColumnDefinition(string columnDefinition)
        {
            GridLength gridLength;
            if (double.TryParse(columnDefinition, NumberStyles.Any, CultureInfo.InvariantCulture, out double width))
                gridLength = new GridLength(width);
            else
                gridLength = columnDefinition switch
                {
                    "*" => new GridLength(1, GridUnitType.Star),
                    _ => new GridLength(1, GridUnitType.Auto)
                };

            return new ColumnDefinition
            {
                Width = gridLength
            };
        }

        /// <summary>
        /// Convert collection of strings to collection of row definitions
        /// </summary>
        /// <param name="rowDefinitions">Collection of row definition strings</param>
        /// <returns>collection of row definitions</returns>
        public static IEnumerable<RowDefinition> ParseRowDefinitions(IEnumerable<string> rowDefinitions) =>
            rowDefinitions.Select(ParseRowDefinition);

        /// <summary>
        /// Convert the row definition string to row definition
        /// </summary>
        /// <param name="rowDefinition">Row definition string</param>
        /// <returns>Row definition</returns>
        public static RowDefinition ParseRowDefinition(string rowDefinition)
        {
            GridLength gridLength;
            if (double.TryParse(rowDefinition, NumberStyles.Any, CultureInfo.InvariantCulture, out double height))
                gridLength = new GridLength(height);
            else
                gridLength = rowDefinition switch
                {
                    "*" => new GridLength(1, GridUnitType.Star),
                    _ => new GridLength(1, GridUnitType.Auto)
                };

            return new RowDefinition
            {
                Height = gridLength
            };
        }
    }
}
