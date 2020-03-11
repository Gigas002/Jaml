using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Jaml.Wpf.Models.StyleModels;

namespace Jaml.Wpf.Providers.StyleProvider
{
    /// <inheritdoc />
    public class StyleProvider : IStyleProvider
    {
        /// <inheritdoc />
        public Dictionary<int, IStyleModel> Styles { get; }

        #region Constructors

        /// <summary>
        /// Creates a new <see cref="StyleProvider"/> with specified styles
        /// </summary>
        /// <param name="styles">Styles for this provider</param>
        public StyleProvider(Dictionary<int, IStyleModel> styles) => Styles = styles;

        /// <summary>
        /// Creates a new <see cref="StyleProvider"/> with empty dictionary of styles
        /// </summary>
        public StyleProvider() => Styles = new Dictionary<int, IStyleModel>();

        #endregion

        #region Methods

        /// <inheritdoc />
        public void RegisterStyles(Dictionary<int, IStyleModel> styles)
        {
            foreach ((int styleId, IStyleModel styleModel) in styles) RegisterStyle(styleId, styleModel);
        }

        /// <inheritdoc />
        public void UnregisterStyles(IEnumerable<int> styleIds)
        {
            foreach (int styleId in styleIds) UnregisterStyle(styleId);
        }

        /// <inheritdoc />
        public void ClearStyles() => Styles.Clear();

        /// <inheritdoc />
        public void RegisterStyle(int styleId, IStyleModel styleModel) => Styles.TryAdd(styleId, styleModel);

        /// <inheritdoc />
        public void UnregisterStyle(int styleId) => Styles.Remove(styleId);

        /// <inheritdoc />
        public IStyleModel GetStyle(int styleId)
        {
            Styles.TryGetValue(styleId, out IStyleModel styleModel);

            return styleModel;
        }

        /// <inheritdoc />
        public void BindStyle<T>(ref T element, int styleId = -1) where T : FrameworkElement
        {
            if (styleId == -1) return;

            //todo check styleModel
            IStyleModel styleModel = Styles.FirstOrDefault(kvp
                                                               => kvp.Key == styleId).Value;

            Style style = new Style();
            styleModel.ToStyle(ref style);
            element.Style = style;
        }

        #endregion
    }
}
