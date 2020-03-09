using System.Collections.Generic;
using Jaml.Wpf.Models.StyleModels;

namespace Jaml.Wpf.Providers.StyleProvider
{
    public interface IStyleProvider
    {
        public Dictionary<int, IStyleModel> Styles { get; }

        public void RegisterStyles(Dictionary<int, IStyleModel> styles);

        public void UnregisterStyles(IEnumerable<int> styleIds);

        public void ClearStyles();

        public void RegisterStyle(int styleId, IStyleModel styleModel);

        public void UnregisterStyle(int styleId);

        public IStyleModel GetStyle(int styleId);
    }
}
