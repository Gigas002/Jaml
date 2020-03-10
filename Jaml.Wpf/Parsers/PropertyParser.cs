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
        /// Parse the <see cref="HorizontalAlignment"/> from string
        /// </summary>
        /// <param name="horizontalAlignment">Horizontal alignment string</param>
        /// <returns>Parsed <see cref="HorizontalAlignment"/></returns>
        public static HorizontalAlignment ParseHorizontalAlignment(string horizontalAlignment) => horizontalAlignment switch
        {
            "Stretch" => HorizontalAlignment.Stretch,
            "Left" => HorizontalAlignment.Left,
            "Right" => HorizontalAlignment.Right,
            _ => HorizontalAlignment.Center
        };

        /// <summary>
        /// Parse the <see cref="VerticalAlignment"/> from string
        /// </summary>
        /// <param name="verticalAlignment">Vertical alignment string</param>
        /// <returns>Parsed <see cref="VerticalAlignment"/></returns>
        public static VerticalAlignment ParseVerticalAlignment(string verticalAlignment) => verticalAlignment switch
        {
            "Stretch" => VerticalAlignment.Stretch,
            "Bottom" => VerticalAlignment.Bottom,
            "Top" => VerticalAlignment.Top,
            _ => VerticalAlignment.Center
        };

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
        /// todo
        /// </summary>
        public static Brush ParseBackground(BackgroundModel background)
        {
            if (background == null) return Brushes.Transparent;

            return background.IsImage ? UIHelper.GetBrushFromImage(background.Value) : ConvertArgbToBrush(background.Value);
        }

        /// <summary>
        /// Converts the thickness string to <see cref="Thickness"/>
        /// </summary>
        /// <param name="thickness">Thickenss string</param>
        /// <returns>Parsed <see cref="Thickness"/></returns>
        public static Thickness ParseThickness(double thickness) => new Thickness(thickness);

        /// <summary>
        /// Converts the visibility string to <see cref="Visibility"/>
        /// </summary>
        /// <param name="visibility">Visibility string</param>
        /// <returns>Parsed <see cref="Visibility"/></returns>
        public static Visibility ParseVisibility(string visibility) => visibility switch
        {
            "Hidden" => Visibility.Hidden,
            "Collapsed" => Visibility.Collapsed,
            _ => Visibility.Visible
        };
    }
}
