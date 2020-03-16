using System;
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
    }
}
