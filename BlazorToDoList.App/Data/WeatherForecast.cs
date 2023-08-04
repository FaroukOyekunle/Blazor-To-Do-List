using System; 

namespace BlazorToDoList.App.Data
{
    // Define the WeatherForecast class to represent weather forecast data.
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        // Property representing the date of the weather forecast.

        public int TemperatureC { get; set; }
        // Property representing the temperature in degrees Celsius.

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        // Computed property (getter-only) representing the temperature in degrees Fahrenheit.
        // The value is calculated based on the TemperatureC property.

        public string Summary { get; set; }
        // Property representing the summary or description of the weather forecast.
    }
}
