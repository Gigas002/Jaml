using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using Jaml.Wpf.Models.UIElementModels;
using Jaml.Wpf.Providers.CommandProvider;
using Jaml.Wpf.Providers.StyleProvider;

// ReSharper disable InconsistentNaming
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace Jaml.Wpf.Models.ChildModels
{
    // ReSharper disable once ClassNeverInstantiated.Global

    /// <summary>
    /// Model of child elements
    /// </summary>
    public class ChildModel
    {
        #region Json Properties

        /// <summary>
        /// Media element. Can be video or audio file
        /// </summary>
        [JsonPropertyName("MediaElement")]
        public MediaElementModel MediaElementModel { get; set; } = null;

        /// <summary>
        /// Non-animated image
        /// </summary>
        [JsonPropertyName("Image")]
        public ImageModel ImageModel { get; set; } = null;

        /// <summary>
        /// Button
        /// </summary>
        [JsonPropertyName("Button")]
        public ButtonModel ButtonModel { get; set; } = null;

        /// <summary>
        /// Grid
        /// </summary>
        [JsonPropertyName("Grid")]
        public GridModel GridModel { get; set; } = null;

        #endregion

        /// <summary>
        /// Get the current <see cref="UIElementModel"/>
        /// </summary>
        /// <returns>Current <see cref="UIElementModel"/></returns>
        public UIElementModel GetUIElementModel() => GetType()
                                                     .GetProperties()
                                                     .Select(propertyInfo => propertyInfo.GetValue(this, null))
                                                     .Where(elementModel => elementModel != null)
                                                     .Select(elementModel => elementModel as UIElementModel)
                                                     .FirstOrDefault();

        /// <summary>
        /// Converts the collection of child models into the <see cref="UIElementCollection"/>
        /// </summary>
        /// <param name="elementCollection">Target collection</param>
        /// <param name="childModels">Collection of elements to convert</param>
        /// <param name="commandProvider">Command provider</param>
        /// <param name="styleProvider">Style provider</param>
        public static void ToUIElementCollection(ref UIElementCollection elementCollection, IEnumerable<ChildModel> childModels,
                                                 ICommandProvider commandProvider, IStyleProvider styleProvider)
        {
            //todo this is working, but it's ugly and bad. Temp solution of moving logics from Parsers.PageParser
            foreach (ChildModel childModel in childModels)
            {
                UIElementModel elementModel = childModel.GetUIElementModel();

                if (elementModel == null) continue;

                Type type = elementModel.GetType();

                if (type == typeof(MediaElementModel))
                {
                    MediaElement me = new MediaElement();
                    MediaElementModel mem = elementModel as MediaElementModel; ;
                    mem?.ToUIElement(ref me, commandProvider, styleProvider);
                    elementCollection.Add(me);

                    //UIElement element = new UIElement();
                    //elementModel.ToUIElement(ref element, commandProvider, styleProvider);
                    //elementCollection.Add(element);
                }
                else if (type == typeof(ButtonModel))
                {
                    Button button = new Button();
                    ButtonModel buttonModel = elementModel as ButtonModel;
                    buttonModel?.ToUIElement(ref button, commandProvider, styleProvider);
                    elementCollection.Add(button);
                }
                else if (type == typeof(ImageModel))
                {
                    Image image = new Image();
                    ImageModel imageModel = elementModel as ImageModel;
                    imageModel?.ToUIElement(ref image, commandProvider, styleProvider);
                    elementCollection.Add(image);
                }
                else if (type == typeof(GridModel))
                {
                    Grid grid = new Grid();
                    GridModel gridModel = elementModel as GridModel;
                    gridModel?.ToUIElement(ref grid, commandProvider, styleProvider);
                    elementCollection.Add(grid);
                }
            }
        }
    }
}
