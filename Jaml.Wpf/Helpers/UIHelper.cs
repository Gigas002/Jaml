using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Jaml.Wpf.Helpers
{
    // ReSharper disable once InconsistentNaming

    /// <summary>
    /// Some common methods to help with UI
    /// </summary>
    public static class UIHelper
    {
        /// <summary>
        /// Creates <see cref="ImageBrush"/> from image
        /// </summary>
        /// <param name="imagePath">Path to image</param>
        /// <returns><see cref="ImageBrush"/> from image</returns>
        public static ImageBrush GetBrushFromImage(string imagePath) => new ImageBrush(new BitmapImage(PathsHelper.GetUriFromRelativePath(imagePath)));

        /// <summary>
        /// Adds <see cref="UIElement"/> to <see cref="Grid"/>
        /// </summary>
        /// <param name="parentGrid">Grid, in which element will be added</param>
        /// <param name="elementToAdd">Element to add on grid</param>
        /// <param name="parentRow">Element's row in grid</param>
        /// <param name="parentColumn">Element's column in grid</param>
        /// <param name="rowSpan">Element's RowSpan in grid</param>
        /// <param name="columnSpan">Element's ColumnSpan in grid</param>
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
