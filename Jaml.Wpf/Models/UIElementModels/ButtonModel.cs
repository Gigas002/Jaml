using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows.Controls;
using Jaml.Wpf.Models.StyleModels;
using Jaml.Wpf.Providers.CommandProvider;

namespace Jaml.Wpf.Models.UIElementModels
{
    // ReSharper disable once ClassNeverInstantiated.Global

    /// <summary>
    /// Model of button
    /// </summary>
    /// <typeparam name="T">Children of <see cref="Button"/></typeparam>
    public class ButtonModel<T> : ButtonBaseModel<T>, IUIElementModel<T> where T : Button, new()
    {
        #region Properties

        /// <summary>
        /// Element's content
        /// </summary>
        [JsonPropertyName("Content")]
        public string Content { get; set; } = string.Empty;

        #endregion

        /// <inheritdoc />
        public override T ToUIElement(ICommandProvider commandProvider = null, IList<StyleModel> styleModels = null)
        {
            T element = base.ToUIElement(commandProvider, styleModels);

            BindProperties(element);

            return element;
        }

        /// <inheritdoc />
        public new void BindProperties(T element, ICommandProvider commandProvider = null,
                                       IList<StyleModel> styleModels = null)
        {
            element.Content = Content;
        }
    }
}
