using System.IO;
using System.Windows;
using System.Windows.Media;
using Jaml.Wpf.Helpers;
using Jaml.Wpf.Models.UIElementModels;

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

            string[] argb = argbString.Trim().Replace(" ", string.Empty).Split(',');

            byte.TryParse(argb[0], out byte a);
            byte.TryParse(argb[1], out byte r);
            byte.TryParse(argb[2], out byte g);
            byte.TryParse(argb[3], out byte b);

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
    }
}
