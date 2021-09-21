using System;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.Services;

namespace PresentationLayer
{
    public class WeatherForecastViewer
    {
        private readonly IWeatherService _weatherService;

        public WeatherForecastViewer(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task ShowWeatherForNow()
        {
            WeatherResponse weather;

            do
            {
                Console.Write("Enter city name:");
                var cityInfo = new CityInfo();
                cityInfo.CityName = Console.ReadLine();

                Console.WriteLine();
                weather = await _weatherService.GetWeather(cityInfo);
            } while (weather == null);

            Console.WriteLine("{0,10}   |{1,10}   |{2,10}", "CityName", "Forecast", "Temperature");
            Console.WriteLine("{0,10}   |{0,10}   |{0,10}", string.Empty);
            Console.WriteLine("{0,10}   |{1,10}   |{2,10}", weather.name, weather.weather.First().main, (weather.main.temp + "°C"));
        }
    }
}