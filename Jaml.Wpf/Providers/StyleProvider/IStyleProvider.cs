using System.Collections.Generic;
using Jaml.Wpf.Models.StyleModels;

namespace Jaml.Wpf.Providers.StyleProvider
{
    /// <summary>
    /// Base interface for style operations
    /// </summary>
    public interface IStyleProvider
    {
        /// <summary>
        /// Dictionary of style models. Key is id, and Value is style model
        /// </summary>
        public Dictionary<int, IStyleModel> StyleModels { get; }

        /// <summary>
        /// Registers all style models from dictionary
        /// </summary>
        /// <param name="styleModels">Dictionary to register</param>
        public void RegisterStyleModels(Dictionary<int, IStyleModel> styleModels);

        /// <summary>
        /// Delete collection of style models with specified keys
        /// </summary>
        /// <param name="styleIds">Collection of keys to delete from dictionary</param>
        public void UnregisterStyleModels(IEnumerable<int> styleIds);

        /// <summary>
        /// Clears dictionary of style models
        /// </summary>
        public void ClearStyleModels();

        /// <summary>
        /// Registers one style model
        /// </summary>
        /// <param name="styleId">Id of style</param>
        /// <param name="styleModel">Style model</param>
        public void RegisterStyleModel(int styleId, IStyleModel styleModel);

        /// <summary>
        /// Delete the specified style model from dictionary
        /// </summary>
        /// <param name="styleId">Id of style</param>
        public void UnregisterStyleModel(int styleId);

        /// <summary>
        /// Gets style model by id
        /// </summary>
        /// <param name="styleId">Id of style model to get</param>
        /// <returns>Element's <see cref="IStyleModel"/></returns>
        public IStyleModel GetStyleModel(int styleId);
    }
}
