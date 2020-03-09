using System;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Jaml.Wpf.Constants;
using Jaml.Wpf.Providers.CommandProvider;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace Jaml.Wpf.Models.CommandModels
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class CommandModel : ICommandModel
    {
        #region Json Properties

        [JsonPropertyName("Event")]
        public string Event { get; set; } = null;

        [JsonPropertyName("Method")]
        public string Method { get; set; } = null;

        [JsonPropertyName("Args")]
        public string Args { get; set; } = null;

        #endregion

        public void BindCommand(UIElement element, ICommandProvider commandProvider)
        {
            //todo use reflection, this is ugly
            switch (Event)
            {
                case EventNames.Initialized:
                {
                    if (element is FrameworkElement frameworkElement)
                        frameworkElement.Initialized += (sender, args) => commandProvider.RunCommand(Method, sender, Args);
                    break;
                }
                case EventNames.Click:
                {
                    if (element is ButtonBase button)
                        button.Click += (sender, args) => commandProvider.RunCommand(Method, sender, Args);
                    break;
                }
                case EventNames.MouseLeftButtonUp:
                {
                    element.MouseLeftButtonUp += (sender, args) => commandProvider.RunCommand(Method, sender, Args);
                    break;
                }
                case EventNames.PreviewMouseLeftButtonUp:
                {
                    element.PreviewMouseLeftButtonUp += (sender, args) => commandProvider.RunCommand(Method, sender, Args);
                    break;
                }
                case EventNames.MouseRightButtonUp:
                {
                    element.MouseRightButtonUp += (sender, args) => commandProvider.RunCommand(Method, sender, Args);
                    break;
                }
                case EventNames.MediaEnded:
                {
                    if (element is MediaElement mediaElement)
                        mediaElement.MediaEnded += (sender, args) => commandProvider.RunCommand(Method, sender, Args);
                    break;
                }
                default: { throw new NotSupportedException($"Event {Event} is not supported."); }
            }
        }
    }
}
