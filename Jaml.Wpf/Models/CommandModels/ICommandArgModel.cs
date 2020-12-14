namespace Jaml.Wpf.Models.CommandModels
{
    /// <summary>
    /// Base interface for command's arg model
    /// </summary>
    public interface ICommandArgModel
    {
        /// <summary>
        /// Name of argument
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Value of argument
        /// </summary>
        public string Value { get; }
    }
}
