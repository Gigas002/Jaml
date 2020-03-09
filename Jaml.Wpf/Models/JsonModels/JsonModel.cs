using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Jaml.Wpf.Models.JsonModels
{
    public class JsonModel : IJsonModel
    {
        public static T GetModel<T>(string filePath) where T : JsonModel
        {
            byte[] bytes = File.ReadAllBytes(filePath);
            return JsonSerializer.Deserialize<T>(GetReadOnlySpan(bytes));
        }

        public static ValueTask<T> GetModelAsync<T>(string filePath) where T : JsonModel => JsonSerializer.DeserializeAsync<T>(File.OpenRead(filePath));

        private static ReadOnlySpan<T> GetReadOnlySpan<T>(T[] t) => new ReadOnlySpan<T>(t);

        public T GetJsonModel<T>(string filePath) where T : IJsonModel
        {
            byte[] bytes = File.ReadAllBytes(filePath);
            return JsonSerializer.Deserialize<T>(GetReadOnlySpan(bytes));
        }
    }
}
