using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using Jaml.Wpf.Models.StyleModels;
using Jaml.Wpf.Providers.CommandProviders;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace Jaml.Wpf.Models.UIElementModels
{
    // ReSharper disable once ClassNeverInstantiated.Global

    /// <summary>
    /// Window model
    /// </summary>
    /// <typeparam name="T">Children of <see cref="Window"/></typeparam>
    public class WindowModel<T> : FrameworkElementModel<T>, IUIElementModel<T> where T : Window, new()
    {
        //todo bind grid as childmodel?
        /// <summary>
        /// Content of the window
        /// </summary>
        [JsonPropertyName("Grid")]
        public GridModel<Grid> GridModel { get; set; } = null;

        /// <inheritdoc />
        public override T ToUIElement(ICommandProvider commandProvider = null, IList<StyleModel> styleModels = null)
        {
            T element = base.ToUIElement(commandProvider, styleModels);

            BindProperties(element, commandProvider, styleModels);

            return element;
        }

        /// <inheritdoc />
        public new void BindProperties(T element, ICommandProvider commandProvider = null, IList<StyleModel> styleModels = null)
        {
            element.Content = GridModel.ToUIElement(commandProvider, styleModels);
        }
    }
}
