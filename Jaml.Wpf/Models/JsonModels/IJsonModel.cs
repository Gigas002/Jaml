// ReSharper disable UnusedMember.Global
namespace Jaml.Wpf.Models.JsonModels
{
    /// <summary>
    /// Base interface for all json models
    /// </summary>
    public interface IJsonModel
    {
        /// <summary>
        /// Parses the model into <see cref="T"/>
        /// </summary>
        /// <typeparam name="T">Children of <see cref="IJsonModel"/></typeparam>
        /// <param name="filePath">Path to json file to parse</param>
        /// <returns>Parsed model</returns>
        public T GetJsonModel<T>(string filePath) where T : IJsonModel;
    }
}
