using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows.Controls;
using Jaml.Wpf.Models.ChildModels;
using Jaml.Wpf.Parsers;
using Jaml.Wpf.Providers.CommandProvider;
using Jaml.Wpf.Providers.StyleProvider;

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
        public override T ToUIElement(ICommandProvider commandProvider, IStyleProvider styleProvider)
        {
            T element = base.ToUIElement(commandProvider, styleProvider);

            BindProperties(element, commandProvider, styleProvider);

            return element;
        }

        /// <inheritdoc />
        public new void BindProperties(T element, ICommandProvider commandProvider, IStyleProvider styleProvider)
        {
            element.Background = PropertyParser.ParseBackground(Background);

            //Bind panel's children
            foreach (ChildModel childModel in Children)
            {
                element.Children.Add(childModel.ToUIElement(commandProvider, styleProvider));
            }

            element.IsItemsHost = IsItemsHost;
        }

        #endregion
    }
}
