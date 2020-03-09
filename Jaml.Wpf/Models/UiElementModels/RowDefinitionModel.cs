using System.Globalization;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace Jaml.Wpf.Models.UiElementModels
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class RowDefinitionModel
    {
        #region Json Properties

        [JsonPropertyName("Height")]
        public string Height { get; set; } = "10.0";

        #endregion

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
