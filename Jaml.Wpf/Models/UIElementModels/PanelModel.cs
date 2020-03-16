﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows.Controls;
using Jaml.Wpf.Models.ChildModels;
using Jaml.Wpf.Parsers;
using Jaml.Wpf.Providers.CommandProvider;
using Jaml.Wpf.Providers.StyleProvider;

namespace Jaml.Wpf.Models.UIElementModels
{
    public class PanelModel : FrameworkElementModel
    {
        #region Properties

        /// <summary>
        /// Panel's background
        /// </summary>
        [JsonPropertyName("Background")]
        public string Background { get; set; } = string.Empty;

        /// <summary>
        /// Collection of children, bound to this panel
        /// </summary>
        [JsonPropertyName("Children")]
        public IEnumerable<ChildModel> Children { get; set; } = new List<ChildModel>();

        /// <summary>
        /// Is items host
        /// </summary>
        [JsonPropertyName("IsItemsHost")]
        public bool IsItemsHost { get; set; } = false;

        #endregion

        #region Methods

        /// <summary>
        /// Converts this model to one of <see cref="Panel"/>'s children
        /// </summary>
        /// <typeparam name="T">Children of <see cref="Panel"/></typeparam>
        /// <param name="element">Element, where model will be converted</param>
        /// <param name="commandProvider">Command provider</param>
        /// <param name="styleProvider">Style provider</param>
        public void ToPanel<T>(ref T element, ICommandProvider commandProvider, IStyleProvider styleProvider) where T : Panel
        {
            //Bind style
            styleProvider.BindStyle(ref element, StyleId);

            //Explicitly initialized properties should override styles

            //Bind properties
            BindProperties(ref element);

            //Bind commands
            commandProvider.BindCommands(ref element, Commands);
        }

        /// <summary>
        /// Binds this element's properties
        /// </summary>
        /// <typeparam name="T">Children of <see cref="Panel"/></typeparam>
        /// <param name="element">Target element to bind properties</param>
        public new void BindProperties<T>(ref T element) where T : Panel
        {
            base.BindProperties(ref element);

            element.Background = PropertyParser.ParseBackground(Background);
            //element.Children; //todo
            element.IsItemsHost = IsItemsHost;
        }

        #endregion
    }
}