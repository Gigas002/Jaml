using System.Collections.Generic;
using Jaml.Wpf.Models.StyleModels;

namespace Jaml.Wpf.Providers.StyleProvider
{
    public class StyleProvider : IStyleProvider
    {
        public Dictionary<int, IStyleModel> Styles { get; }

        #region Constructors

        public StyleProvider(Dictionary<int, IStyleModel> styles) => Styles = styles;

        public StyleProvider() => Styles = new Dictionary<int, IStyleModel>();

        #endregion

        public void RegisterStyles(Dictionary<int, IStyleModel> styles)
        {
            foreach ((int styleId, IStyleModel styleModel) in styles) RegisterStyle(styleId, styleModel);
        }

        public void UnregisterStyles(IEnumerable<int> styleIds)
        {
            foreach (int styleId in styleIds) UnregisterStyle(styleId);
        }

        public void ClearStyles() => Styles.Clear();

        public void RegisterStyle(int styleId, IStyleModel styleModel) => Styles.TryAdd(styleId, styleModel);

        public void UnregisterStyle(int styleId) => Styles.Remove(styleId);

        public IStyleModel GetStyle(int styleId)
        {
            Styles.TryGetValue(styleId, out IStyleModel styleModel);

            return styleModel;
        }
    }
}
