using System.Windows;
using Jaml.Wpf.Providers.CommandProvider;

// ReSharper disable UnusedMemberInSuper.Global

namespace Jaml.Wpf.Models.CommandModels
{
    public interface ICommandModel
    {
        public string Event { get; }

        public string Method { get; }

        public string Args { get; }

        public void BindCommand(UIElement element, ICommandProvider commandProvider);
    }
}
