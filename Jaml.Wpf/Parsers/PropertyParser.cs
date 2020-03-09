using System.Windows;
using System.Windows.Media;
using Jaml.Wpf.Helpers;
using Jaml.Wpf.Models.UiElementModels;

namespace Jaml.Wpf.Parsers
{
    public static class PropertyParser
    {
        public static HorizontalAlignment ParseHorizontalAlignment(string horizontalAlignment) => horizontalAlignment switch
        {
            "Stretch" => HorizontalAlignment.Stretch,
            "Left" => HorizontalAlignment.Left,
            "Right" => HorizontalAlignment.Right,
            _ => HorizontalAlignment.Center
        };

        public static VerticalAlignment ParseVerticalAlignment(string verticalAlignment) => verticalAlignment switch
        {
            "Stretch" => VerticalAlignment.Stretch,
            "Bottom" => VerticalAlignment.Bottom,
            "Top" => VerticalAlignment.Top,
            _ => VerticalAlignment.Center
        };

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

        public static FontStyle ParseFontStyle(string fontStyle) => fontStyle switch
        {
            "Italic" => FontStyles.Italic,
            "Oblique" => FontStyles.Oblique,
            _ => FontStyles.Normal
        };

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

        public static Brush ParseBackground(BackgroundModel background)
        {
            if (background == null) return Brushes.Transparent;

            return background.IsImage ? UIHelper.GetBrushFromImage(background.Value) : ConvertArgbToBrush(background.Value);
        }

        public static Thickness ParseThickness(double thickness) => new Thickness(thickness);

        public static Visibility ParseVisibility(string visibility) => visibility switch
        {
            "Hidden" => Visibility.Hidden,
            "Collapsed" => Visibility.Collapsed,
            _ => Visibility.Visible
        };
    }
}
