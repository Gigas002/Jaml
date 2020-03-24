using System;
using System.Text.Json.Serialization;
using System.Windows.Controls.Primitives;
using Jaml.Wpf.Providers.CommandProvider;
using Jaml.Wpf.Providers.StyleProvider;

namespace Jaml.Wpf.Models.UIElementModels
{
    /// <summary>
    /// Base button model
    /// </summary>
    /// <typeparam name="T">Children of <see cref="ButtonBase"/></typeparam>
    public class ButtonBaseModel<T> : FrameworkElementModel<T>, IUIElementModel<T> where T : ButtonBase, new()
    {
        #region Properties

        /// <summary>
        /// Click mode
        /// </summary>
        [JsonPropertyName("ClickMode")]
        public string ClickMode { get; set; } = "Release";

        #endregion

        #region Methods

        /// <inheritdoc />
        public override T ToUIElement(ICommandProvider commandProvider, IStyleProvider styleProvider)
        {
            T element = base.ToUIElement(commandProvider, styleProvider);

            BindProperties(element, null, styleProvider);

            return element;
        }

        /// <inheritdoc />
        public new void BindProperties(T element, ICommandProvider commandProvider = null,
                                       IStyleProvider styleProvider = null)
        {
            Enum.TryParse(ClickMode, out System.Windows.Controls.ClickMode clickMode);
            element.ClickMode = clickMode;
            //element.Command;
            //element.CommandParameter;
            //element.CommandTarget;
        }

        #endregion
    }
}
