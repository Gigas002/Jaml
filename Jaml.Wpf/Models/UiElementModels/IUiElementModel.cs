using System.Collections.Generic;
using System.Windows;
using Jaml.Wpf.Models.CommandModels;
using Jaml.Wpf.Models.StyleModels;
using Jaml.Wpf.Providers.CommandProvider;
using Jaml.Wpf.Providers.StyleProvider;

// ReSharper disable UnusedMemberInSuper.Global

namespace Jaml.Wpf.Models.UiElementModels
{
    public interface IUiElementModel
    {
        public string Name { get; }

        public string VerticalAlignment { get; }

        public string HorizontalAlignment { get; }

        public string Content { get; }

        public int StyleId { get; }

        public int ParentRow { get; }

        public int ParentColumn { get; }

        public int RowSpan { get; }

        public int ColumnSpan { get; }

        public IEnumerable<CommandModel> Commands { get; }

        public T ToUiElement<T>(ICommandProvider commandProvider, IStyleProvider styleProvider) where T : UIElement;

        public IStyleModel GetCorrespondingStyle(IStyleProvider styleProvider);
    }
}
