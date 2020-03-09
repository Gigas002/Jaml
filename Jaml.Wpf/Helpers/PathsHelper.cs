using System;
using System.IO;

namespace Jaml.Wpf.Helpers
{
    /// <summary>
    /// Shortcuts to help with paths
    /// </summary>
    public static class PathsHelper
    {
        /// <summary>
        /// Create <see cref="Uri"/> from relative path string
        /// </summary>
        /// <param name="relativePath">Relative path</param>
        /// <returns><see cref="Uri"/> with full path</returns>
        public static Uri GetUriFromRelativePath(string relativePath) => new Uri(Path.GetFullPath(relativePath));
    }
}
