using System;
using System.Linq;
using BusinessLayer.Services;
using PresentationLayer.Viewers;

namespace PresentationLayer.Commands.Impl
{
    public class GetHottestCityCmdCommand : BaseCmdCommand
    {
        private readonly IWeatherService _weatherService;
        private readonly IWeatherForecastViewer _weatherForecastViewer;

        public GetHottestCityCmdCommand(IWeatherService weatherService, IWeatherForecastViewer weatherForecastViewer)
        {
            _weatherService = weatherService ?? throw new ArgumentNullException(nameof(weatherService));
            _weatherForecastViewer = weatherForecastViewer ?? throw new ArgumentNullException(nameof(weatherForecastViewer));
        }

        protected override string CommandPattern => "3";
        public override string CommandMessage => "3.Select hottest city.";

        protected override void Execute()
        {

        CityNameReading:

            Console.Write("Enter city name:");
            var cityName = Console.ReadLine();
            long requestDelay = long.MinValue;

            if (string.IsNullOrWhiteSpace(cityName))
            {
                Console.WriteLine("Wrong or empty input! Please, try again.");
                goto CityNameReading;
            }

            var listOfCities = cityName.Split(" ").ToList();

            (cityName, requestDelay) = _weatherService.GetHottestCityAsync(listOfCities).GetAwaiter().GetResult();

            _weatherForecastViewer.ShowHottestCity(cityName, requestDelay);
        }
    }
}