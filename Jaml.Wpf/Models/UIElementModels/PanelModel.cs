using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows.Controls;
using Jaml.Wpf.Exceptions;
using Jaml.Wpf.Models.ChildModels;
using Jaml.Wpf.Models.StyleModels;
using Jaml.Wpf.Parsers;
using Jaml.Wpf.Providers.CommandProviders;

namespace Jaml.Wpf.Models.UIElementModels
{
    /// <summary>
    /// Base class for panel models
    /// </summary>
    /// <typeparam name="T">Children of <see cref="Panel"/></typeparam>
    public class PanelModel<T> : FrameworkElementModel<T>, IUIElementModel<T> where T : Panel, new()
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
            if (element is null) throw new UIException(nameof(element));

            element.Background = PropertyParser.ParseBackground(Background);

            //Bind panel's children
            foreach (ChildModel childModel in Children)
            {
                element.Children.Add(childModel.ToUIElement(commandProvider, styleModels));
            }

            element.IsItemsHost = IsItemsHost;
        }

        #endregion
    }
}
