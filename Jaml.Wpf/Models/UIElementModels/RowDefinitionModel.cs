using System.Globalization;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace Jaml.Wpf.Models.UIElementModels
{
    // ReSharper disable once ClassNeverInstantiated.Global

    /// <summary>
    /// Grid's row definition model
    /// </summary>
    public class RowDefinitionModel
    {
        #region Json Properties

        /// <summary>
        /// Height of the column
        /// </summary>
        [JsonPropertyName("Height")]
        public string Height { get; set; } = "10.0";

        #endregion

        /// <summary>
        /// Converts this model to <see cref="RowDefinition"/>
        /// </summary>
        /// <returns>Converted <see cref="RowDefinition"/></returns>
        public RowDefinition ToRowDefinition()
        {
            GridLength gridLength;
            if (double.TryParse(Height, NumberStyles.Any, CultureInfo.InvariantCulture, out double height))
                gridLength = new GridLength(height);
            else
                gridLength = Height switch
                {
                    "*" => new GridLength(1, GridUnitType.Star),
                    _ => new GridLength(1, GridUnitType.Auto),
                };
            return new RowDefinition
            {
                Height = gridLength
            };
        }
    }
}
