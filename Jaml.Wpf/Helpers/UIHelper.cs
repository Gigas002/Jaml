using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Jaml.Wpf.Helpers
{
    // ReSharper disable once InconsistentNaming
    public static class UIHelper
    {
        public static ImageBrush GetBrushFromImage(string imagePath) => new ImageBrush(new BitmapImage(PathsHelper.GetUriFromRelativePath(imagePath)));

        public static void AddElementToGrid(Grid parentGrid, UIElement elementToAdd, int parentRow, int parentColumn,
                                            int rowSpan, int columnSpan)
        {
            Grid.SetRow(elementToAdd, parentRow);
            Grid.SetColumn(elementToAdd, parentColumn);
            Grid.SetRowSpan(elementToAdd, rowSpan);
            Grid.SetColumnSpan(elementToAdd, columnSpan);

            parentGrid.Children.Add(elementToAdd);
        }
    }
}
