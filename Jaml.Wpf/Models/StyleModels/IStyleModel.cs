using System.Windows;
using Jaml.Wpf.Models.UiElementModels;

namespace Jaml.Wpf.Models.StyleModels
{
    public interface IStyleModel
    {
        public int Id { get; }

        public double FontSize { get; }

        public string FontFamily { get; }

        public string FontStyle { get; }

        public string FontWeight { get; }

        public string Foreground { get; }

        //todo
        public BackgroundModel Background { get; }

        public double BorderThickness { get; }

        public string Visibility { get; }

        public Style ToStyle();

        public void BindStyle(FrameworkElement element);
    }
}
