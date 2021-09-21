using System;
using System.Linq;
using BusinessLayer;
using BusinessLayer.Services;
using System.Threading.Tasks;
using BusinessLayer.DTO;
using BusinessLayer.DTO.JSON;

namespace PresentationLayer
{
    public class WeatherForecastViewer
    {
        private readonly IWeatherService _weatherService;

        public WeatherForecastViewer(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public void Run()
        {
            Start:
            Console.WriteLine("Choose forecast option:");
            Console.WriteLine("1.Forecast for now.");
            Console.WriteLine("2.Forecast for a few days.");

            switch (Console.ReadLine())
            {
                case "1":
                    ShowWeatherForNow().GetAwaiter().GetResult();
                    break;
                case "2":
                    ShowWeatherForecast().GetAwaiter().GetResult();
                    break;
                default:
                    Console.WriteLine("Wrong input!");
                    goto Start;
                    break;

            }
        }


        private async Task ShowWeatherForNow()
        {
            WeatherDto weatherForecast;

            do
            {
                Console.Write("Enter city name:");
                var forecastDto = new WeatherForecastDto();
                forecastDto.CityName = Console.ReadLine();

                Console.WriteLine();
                weatherForecast = await _weatherService.GetWeatherForNow(forecastDto);
            } while (weatherForecast == null);

            Console.WriteLine("{0,10}   |{1,10}   |{2,10}", "City", "Forecast", "Temperature");
            Console.WriteLine("{0,10}   |{0,10}   |{0,10}", string.Empty);
            Console.WriteLine("{0,10}   |{1,10}   |{2,10}", weatherForecast.CityName, weatherForecast.Description, (weatherForecast.DayTemperature + "°C"));
        }
        private async Task ShowWeatherForecast()
        {
            int daysCount;
            var forecastDto = new WeatherForecastDto();

            do
            {
                Console.Write("Enter city name:");
                forecastDto.CityName = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(forecastDto.CityName));

            do
            {
                Console.Write("Enter forecast days count,more than 0 but lower than 16:");
            } while (!Int32.TryParse(Console.ReadLine(), out daysCount) || daysCount is < 1 or > 16);

            forecastDto.DaysCount = daysCount;
            var weatherForecast = await _weatherService.GetWeatherForecast(forecastDto);

            Console.WriteLine($"Forecast for {weatherForecast.CityName} weather for {weatherForecast.DaysCount} days:");
            Console.WriteLine("{0,10}   |{1,15}   |{2,10}", "Date", "Forecast", "Temperature");
            Console.WriteLine("{0,10}   |{0,15}   |{0,10}", string.Empty);

            foreach (var forecast in weatherForecast.Weather)
            {
                var date = forecast.Date.ToString("d");
                Console.WriteLine("{0,10}   |{1,15}   |{2,10}", date, forecast.Description, (forecast.DayTemperature + "°C"));
            }
        }
    }
}