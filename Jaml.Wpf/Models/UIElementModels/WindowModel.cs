﻿using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
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
        //todo bind grid as childmodel?
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
            //Bind properties
            BindProperties(ref window, commandProvider, styleProvider);
        }

        /// <summary>
        /// Binds model properies from model to passed element
        /// </summary>
        /// <typeparam name="T">Children of <see cref="Window"/></typeparam>
        /// <param name="element">Element to take properties</param>
        /// <param name="commandProvider">Command provider</param>
        /// <param name="styleProvider">Style provider</param>
        public new void BindProperties<T>(ref T element, ICommandProvider commandProvider, IStyleProvider styleProvider) where T : Window
        {
            base.BindProperties(ref element, commandProvider, styleProvider);

            //todo
            Grid contentGrid = new Grid();
            GridModel.ToGrid(ref contentGrid, commandProvider, styleProvider);
            element.Content = contentGrid;
        }
    }
}
