using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                dynamic elementModel = childModel.GetUIElementModel();

                if (elementModel == null) continue;

                Type modelType = elementModel.GetType();
                MethodInfo[] modelMethods = modelType.GetMethods();
                MethodInfo genericMethod = modelMethods.Where(m => m.IsGenericMethod).First(m => m.Name == "ToUIElement").GetGenericMethodDefinition();

                Type elemType = genericMethod.ReturnType.BaseType;
                dynamic element = Activator.CreateInstance(elemType);
                elementModel.ToUIElement(element, commandProvider, styleProvider);
                elementCollection.Add(element);
            }
        }
    }
}
