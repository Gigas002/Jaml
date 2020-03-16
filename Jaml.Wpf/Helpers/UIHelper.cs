using System;
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
        /// Creates <see cref="Brush"/> from image
        /// </summary>
        /// <param name="imagePath">Path to image</param>
        /// <returns><see cref="Brush"/> from image</returns>
        public static Brush GetBrushFromImage(string imagePath)
        {
            ImageBrush imageBrush;

            try { imageBrush = new ImageBrush(new BitmapImage(PathsHelper.GetUriFromRelativePath(imagePath))); }
            catch (Exception)
            {
                //#if DEBUG
                //MessageBox.Show(exception.Message);
                //#endif
                return Brushes.Transparent;
            }

            return imageBrush;
        }

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
