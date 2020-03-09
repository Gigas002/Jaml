using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Jaml.Wpf.Models.JsonModels
{
    /// <summary>
    /// Base class for parsing json models
    /// </summary>
    public class JsonModel : IJsonModel
    {
        private static ReadOnlySpan<T> GetReadOnlySpan<T>(T[] t) => new ReadOnlySpan<T>(t);

        /// <summary>
        /// Parses the model into <see cref="T"/>
        /// </summary>
        /// <typeparam name="T">Children of <see cref="IJsonModel"/></typeparam>
        /// <param name="filePath">Path to json file to parse</param>
        /// <returns>Parsed model</returns>
        public static T GetModel<T>(string filePath) where T : IJsonModel
        {
            byte[] bytes = File.ReadAllBytes(filePath);
            return JsonSerializer.Deserialize<T>(GetReadOnlySpan(bytes));
        }

        /// <summary>
        /// Asynchroniously parses the model into <see cref="T"/>
        /// </summary>
        /// <typeparam name="T">Children of <see cref="IJsonModel"/></typeparam>
        /// <param name="filePath">Path to json file to parse</param>
        /// <returns>Parsed model</returns>
        public static ValueTask<T> GetModelAsync<T>(string filePath) where T : IJsonModel => JsonSerializer.DeserializeAsync<T>(File.OpenRead(filePath));

        /// <inheritdoc />
        public T GetJsonModel<T>(string filePath) where T : IJsonModel
        {
            byte[] bytes = File.ReadAllBytes(filePath);
            return JsonSerializer.Deserialize<T>(GetReadOnlySpan(bytes));
        }
    }
}
