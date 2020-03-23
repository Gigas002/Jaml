using System.Collections.Generic;
using Jaml.Wpf.Models.StyleModels;

namespace Jaml.Wpf.Providers.StyleProvider
{
    /// <inheritdoc />
    public class StyleProvider : IStyleProvider
    {
        /// <inheritdoc />
        public Dictionary<int, IStyleModel> StyleModels { get; }

        #region Constructors

        /// <summary>
        /// Creates a new <see cref="StyleProvider"/> with specified styles
        /// </summary>
        /// <param name="styles">Styles for this provider</param>
        public StyleProvider(Dictionary<int, IStyleModel> styles) => StyleModels = styles;

        /// <summary>
        /// Creates a new <see cref="StyleProvider"/> with empty dictionary of styles
        /// </summary>
        public StyleProvider() => StyleModels = new Dictionary<int, IStyleModel>();

        #endregion

        #region Methods

        /// <inheritdoc />
        public void RegisterStyleModels(Dictionary<int, IStyleModel> styles)
        {
            foreach ((int styleId, IStyleModel styleModel) in styles) RegisterStyleModel(styleId, styleModel);
        }

        /// <inheritdoc />
        public void UnregisterStyleModels(IEnumerable<int> styleIds)
        {
            foreach (int styleId in styleIds) UnregisterStyleModel(styleId);
        }

        /// <inheritdoc />
        public void ClearStyleModels() => StyleModels.Clear();

        /// <inheritdoc />
        public void RegisterStyleModel(int styleId, IStyleModel styleModel) => StyleModels.TryAdd(styleId, styleModel);

        /// <inheritdoc />
        public void UnregisterStyleModel(int styleId) => StyleModels.Remove(styleId);

        /// <inheritdoc />
        public IStyleModel GetStyleModel(int styleId)
        {
            if (styleId == -1) return null;

            StyleModels.TryGetValue(styleId, out IStyleModel styleModel);

            return styleModel;
        }

        #endregion
    }
}
