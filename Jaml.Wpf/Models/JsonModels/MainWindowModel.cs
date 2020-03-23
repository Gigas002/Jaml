using System.Text.Json.Serialization;
using System.Windows;
using Jaml.Wpf.Models.UIElementModels;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace Jaml.Wpf.Models.JsonModels
{
    // ReSharper disable once ClassNeverInstantiated.Global

    /// <summary>
    /// Model of MainWindow.json
    /// </summary>
    public class MainWindowModel<T> : JsonModel where T : Window, new()
    {
        /// <summary>
        /// Json's main window element
        /// </summary>
        [JsonPropertyName("MainWindow")]
        public MainWindowModel<T> MainWindow { get; set; } = null;

        /// <summary>
        /// Window inside of MainWindow
        /// </summary>
        [JsonPropertyName("Window")]
        public WindowModel<T> WindowModel { get; set; } = null;
    }
}
