﻿using System.Text.Json.Serialization;
using System.Windows.Controls.Primitives;
using Jaml.Wpf.Providers.CommandProvider;
using Jaml.Wpf.Providers.StyleProvider;

namespace Jaml.Wpf.Models.UIElementModels
{
    // ReSharper disable once ClassNeverInstantiated.Global

    /// <summary>
    /// Model of button
    /// </summary>
    public class ButtonModel<T> : FrameworkElementModel<T>, IUIElementModel<T> where T : ButtonBase, new()
    {
        #region Properties

        /// <summary>
        /// Element's content
        /// </summary>
        [JsonPropertyName("Content")]
        public string Content { get; set; } = string.Empty;

        #endregion

        /// <inheritdoc />
        public override T ToUIElement(ICommandProvider commandProvider, IStyleProvider styleProvider)
        {
            T element = base.ToUIElement(commandProvider, styleProvider);

            BindProperties(element, null, null);

            return element;
        }

        /// <inheritdoc />
        public new void BindProperties(T element, ICommandProvider commandProvider, IStyleProvider styleProvider)
        {
            element.Content = Content;
        }
    }
}
