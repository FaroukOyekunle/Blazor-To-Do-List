using System; 
using System.Linq; 
using System.Threading.Tasks; 

namespace BlazorToDoList.App.Data
{
    // Define the WeatherForecastService class to provide weather forecast data.
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        // An array of weather summary strings used for generating random summaries.

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            // Method to asynchronously get weather forecasts starting from the provided date.
            // It returns a Task representing the asynchronous operation that will yield an array of WeatherForecast.

            var rng = new Random(); // Create a Random instance to generate random numbers.

            // Use LINQ to generate an array of WeatherForecast with 5 elements.
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index), // Increment the date by the index to get future dates.
                TemperatureC = rng.Next(-20, 55), // Generate a random temperature in Celsius between -20 and 55.
                Summary = Summaries[rng.Next(Summaries.Length)] // Randomly select a weather summary from the Summaries array.
            }).ToArray()); // Convert the IEnumerable<WeatherForecast> to an array and wrap it in a Task.
        }
    }
}
