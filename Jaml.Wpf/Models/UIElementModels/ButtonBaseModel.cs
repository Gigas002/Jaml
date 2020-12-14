using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows.Controls.Primitives;
using Jaml.Wpf.Models.CommandModels;
using Jaml.Wpf.Models.StyleModels;
using Jaml.Wpf.Providers.CommandProviders;

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

        #region EventNames

        internal const string Click = nameof(Click);

        #endregion

        #region Methods

        /// <inheritdoc />
        public override T ToUIElement(ICommandProvider commandProvider = null, IList<StyleModel> styleModels = null)
        {
            T element = base.ToUIElement(commandProvider, styleModels);

            BindProperties(element);

            BindCommands(element, commandProvider);

            return element;
        }

        /// <inheritdoc />
        public new void BindProperties(T element, ICommandProvider commandProvider = null,
                                       IList<StyleModel> styleModels = null)
        {
            Enum.TryParse(ClickMode, out System.Windows.Controls.ClickMode clickMode);
            element.ClickMode = clickMode;
            //element.Command;
            //element.CommandParameter;
            //element.CommandTarget;
        }

        /// <inheritdoc />
        public new void BindCommand(T element, ICommandModel commandModel, ICommandProvider commandProvider)
        {
            string eventName = commandModel.Event;
            string methodName = commandModel.Method;
            IEnumerable<ICommandArgModel> methodArgs = commandModel.Args;

            switch (eventName)
            {
                case Click:
                {
                    if (element is ButtonBase button)
                        button.Click += (sender, args) => commandProvider.RunCommand(methodName, sender, methodArgs);

                    break;
                }
                default:
                {
                    break;
                    //throw new NotSupportedException($"Event {eventName} is not supported.");
                }
            }
        }

        /// <inheritdoc />
        public new void BindCommands(T element, ICommandProvider commandProvider)
        {
            foreach (ICommandModel commandModel in Commands)
                BindCommand(element, commandModel, commandProvider);
        }

        #endregion
    }
}
