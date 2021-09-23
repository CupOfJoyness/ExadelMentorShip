using System;
using BusinessLayer.DTO;
using BusinessLayer.Services;
using PresentationLayer.Viewers;

namespace PresentationLayer.Commands.Impl
{
    public class GetWeatherForNowCmdCommand : BaseCmdCommand
    {
        private readonly IWeatherService _weatherService;
        private readonly IWeatherForecastViewer _weatherForecastViewer;

        public GetWeatherForNowCmdCommand(IWeatherService weatherService, IWeatherForecastViewer weatherForecastViewer)
        {
            _weatherService = weatherService ?? throw new ArgumentNullException(nameof(weatherService));
            _weatherForecastViewer = weatherForecastViewer ?? throw new ArgumentNullException(nameof(weatherForecastViewer));
        }

        protected override string CommandPattern => "1";
        public override string CommandMessage => "1.Forecast for now.";

        protected override void Execute()
        {
            WeatherForecastDto forecastDto;

            Console.Write("Enter city name:");
            var cityName = Console.ReadLine();

            do
            { 
                Console.WriteLine("Wrong or empty input! Please, try again.");
            } while (string.IsNullOrWhiteSpace(cityName));

            try
            {
                forecastDto = _weatherService.GetWeatherForNowAsync(cityName).GetAwaiter().GetResult();
            }
            catch (System.Net.WebException)
            {
                throw new System.Net.WebException("Can't find city with such name.");
            }

            _weatherForecastViewer.ShowWeatherForecast(forecastDto);
        }
    }
}