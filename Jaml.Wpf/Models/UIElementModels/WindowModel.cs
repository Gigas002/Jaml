using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using Jaml.Wpf.Parsers;
using Jaml.Wpf.Providers.CommandProvider;
using Jaml.Wpf.Providers.StyleProvider;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace Jaml.Wpf.Models.UIElementModels
{
    // ReSharper disable once ClassNeverInstantiated.Global

    /// <summary>
    /// Window model
    /// </summary>
    public class WindowModel : FrameworkElementModel
    {
        /// <summary>
        /// Content of the window
        /// </summary>
        [JsonPropertyName("Grid")]
        public GridModel GridModel { get; set; } = null;

        /// <summary>
        /// Creates window from model
        /// </summary>
        /// <typeparam name="T">Children of <see cref="Window"/></typeparam>
        /// <param name="window">Target window</param>
        /// <param name="commandProvider">Command provider</param>
        /// <param name="styleProvider">Style provider</param>
        public void ToWindow<T>(ref T window, ICommandProvider commandProvider, IStyleProvider styleProvider) where T : Window
        {
            //Bind styles
            styleProvider.BindStyle(ref window, StyleId);

            //Explicitly initialized properties should override styles

            //Bind properties
            Grid contentGrid = new Grid();
            GridModel.ToGrid(ref contentGrid, commandProvider, styleProvider);
            window.Content = contentGrid;
            window.VerticalAlignment = PropertyParser.ParseVerticalAlignment(VerticalAlignment);
            window.HorizontalAlignment = PropertyParser.ParseHorizontalAlignment(HorizontalAlignment);

            //Bind commands
            commandProvider.BindCommands(ref window, Commands);
        }
    }
}
