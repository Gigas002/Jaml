using System.Text.Json.Serialization;
using Jaml.Wpf.Models.UIElementModels;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace Jaml.Wpf.Models.JsonModels
{
    // ReSharper disable once ClassNeverInstantiated.Global

    /// <summary>
    /// Model of MainWindow.json
    /// </summary>
    public class MainWindowModel : JsonModel
    {
        /// <summary>
        /// Json's main window element
        /// </summary>
        [JsonPropertyName("MainWindow")]
        public MainWindowModel MainWindow { get; set; } = null;

        /// <summary>
        /// Window inside of MainWindow
        /// </summary>
        [JsonPropertyName("Window")]
        public WindowModel WindowModel { get; set; } = null;
    }
}
