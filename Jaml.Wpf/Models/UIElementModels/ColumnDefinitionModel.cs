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
    /// Grid's column definition model
    /// </summary>
    public class ColumnDefinitionModel
    {
        #region Json Properties

        /// <summary>
        /// Width of the column
        /// </summary>
        [JsonPropertyName("Width")]
        public string Width { get; set; } = "10.0";

        #endregion

        /// <summary>
        /// Converts this model to <see cref="ColumnDefinition"/>
        /// </summary>
        /// <returns>Converted <see cref="ColumnDefinition"/></returns>
        public ColumnDefinition ToColumnDefinition()
        {
            GridLength gridLength;
            if (double.TryParse(Width, NumberStyles.Any, CultureInfo.InvariantCulture, out double width))
                gridLength = new GridLength(width);
            else
                gridLength = Width switch
                {
                    "*" => new GridLength(1, GridUnitType.Star),
                    _ => new GridLength(1, GridUnitType.Auto),
                };
            return new ColumnDefinition
            {
                Width = gridLength
            };
        }
    }
}
