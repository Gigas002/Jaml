using System;
using System.IO;

namespace Jaml.Wpf.Helpers
{
    public static class PathsHelper
    {
        public static Uri GetUriFromRelativePath(string relativePath) => new Uri(Path.GetFullPath(relativePath));
    }
}
