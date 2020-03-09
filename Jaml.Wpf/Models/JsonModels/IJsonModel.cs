// ReSharper disable UnusedMember.Global
namespace Jaml.Wpf.Models.JsonModels
{
    public interface IJsonModel
    {
        public T GetJsonModel<T>(string filePath) where T : IJsonModel;
    }
}
