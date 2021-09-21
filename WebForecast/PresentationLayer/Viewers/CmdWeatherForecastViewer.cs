using System;
using System.Linq;
using BusinessLayer.DTO;

namespace PresentationLayer.Viewers
{
    public class CmdWeatherForecastViewer : IWeatherForecastViewer
    {
        public void ShowWeatherForecast(WeatherForecastDto forecastDto)
        {
            if (forecastDto.Equals(null)) throw new ArgumentNullException(nameof(forecastDto));

            if (!forecastDto.Weather.Any()) throw new ArgumentException(nameof(forecastDto.Weather));
            if (forecastDto.DaysCount is < 0 or > 16) throw new ArgumentException(nameof(forecastDto.DaysCount));

            Console.Write($"Forecast for {forecastDto.CityName} weather for ");

            Console.WriteLine(forecastDto.DaysCount > 1 ? $"{forecastDto.DaysCount} days:" : $"today:");

            Console.WriteLine("{0,10}   |{1,15}   |{2,10}", "Date", "Forecast", "Temperature");
            Console.WriteLine("{0,10}   |{0,15}   |{0,10}", string.Empty);

            foreach (var forecast in forecastDto.Weather)
            {
                var date = forecast.Date.ToString("d");
                Console.WriteLine("{0,10}   |{1,15}   |{2,10}", date, forecast.Description, (forecast.DayTemperature + "°C"));
            }
        }
    }
}