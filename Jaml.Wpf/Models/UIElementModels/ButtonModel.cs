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
    public class ButtonModel : FrameworkElementModel
    {
        #region Properties

        /// <summary>
        /// Element's content
        /// </summary>
        [JsonPropertyName("Content")]
        public string Content { get; set; } = string.Empty;

        #endregion

        /// <summary>
        /// Creates button from model
        /// </summary>
        /// <typeparam name="T">Children of <see cref="ButtonBase"/></typeparam>
        /// <param name="element">Target button</param>
        /// <param name="commandProvider">Command provider</param>
        /// <param name="styleProvider">Style provider</param>
        public new void ToUIElement<T>(T element, ICommandProvider commandProvider, IStyleProvider styleProvider)
            where T : ButtonBase
        {
            base.ToUIElement(element, commandProvider, styleProvider);

            BindProperties(element, commandProvider, styleProvider);
        }

        /// <summary>
        /// Binds model properies from model to passed element
        /// </summary>
        /// <typeparam name="T">Children of <see cref="ButtonBase"/></typeparam>
        /// <param name="element">Element to take properties</param>
        /// <param name="commandProvider">Command provider</param>
        /// <param name="styleProvider">Style provider</param>
        public new void BindProperties<T>(T element, ICommandProvider commandProvider, IStyleProvider styleProvider) where T : ButtonBase
        {
            element.Content = Content;
        }
    }
}
