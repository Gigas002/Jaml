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
        public MediaElementModel<MediaElement> MediaElementModel { get; set; } = null;

        /// <summary>
        /// Non-animated image
        /// </summary>
        [JsonPropertyName("Image")]
        public ImageModel<Image> ImageModel { get; set; } = null;

        /// <summary>
        /// Button
        /// </summary>
        [JsonPropertyName("Button")]
        public ButtonModel<Button> ButtonModel { get; set; } = null;

        /// <summary>
        /// Grid
        /// </summary>
        [JsonPropertyName("Grid")]
        public GridModel<Grid> GridModel { get; set; } = null;

        #endregion

        /// <summary>
        /// Get the current UIElementModel
        /// </summary>
        /// <returns>Current UIElementModel as object</returns>
        public object GetUIElementModel()
        {
            foreach (PropertyInfo property in GetType().GetProperties())
            {
                var thisModel = property.GetValue(this, null);

                if (thisModel != null) return thisModel;
            }

            return null;
        }

        /// <summary>
        /// Get the current UIElementModel
        /// </summary>
        /// <returns>Current UIElementModel</returns>
        public IUIElementModel<T> GetUIElementModel<T>() where T : UIElement, new()
        {
            foreach (PropertyInfo property in GetType().GetProperties())
            {
                var thisModel = property.GetValue(this, null);

                if (thisModel != null) return thisModel as IUIElementModel<T>;
            }

            return null;
        }

        /// <summary>
        /// Convert this child to UIElement
        /// </summary>
        /// <param name="commandProvider"></param>
        /// <param name="styleProvider"></param>
        /// <returns></returns>
        public UIElement ToUIElement(ICommandProvider commandProvider,
                                     IStyleProvider styleProvider)
        {
            //IUIElementModel<MediaElement> elementModel = GetUIElementModel<MediaElement>();
            dynamic elementModel = GetUIElementModel();

            return elementModel.ToUIElement(commandProvider, styleProvider) as UIElement;
        }
    }
}
