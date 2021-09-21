using System;
using BusinessLayer.DTO;
using BusinessLayer.Services;
using System.Threading.Tasks;
using PresentationLayer.Viewers;

namespace PresentationLayer.Commands.Impl
{
    public class GetWeaherForNowCmdCommand : BaseCmdCommand
    {
        private readonly IWeatherService _weatherService;
        private readonly IWeatherForecastViewer _weatherForecastViewer;

        public GetWeaherForNowCmdCommand(IWeatherService weatherService, IWeatherForecastViewer weatherForecastViewer)
        {
            _weatherService = weatherService ?? throw new ArgumentNullException(nameof(weatherService));
            _weatherForecastViewer = weatherForecastViewer ?? throw new ArgumentNullException(nameof(weatherForecastViewer));
        }

        protected override string CommandPattern => "1";
        public override string CommandMessange => "1.Forecast for now.";

        protected override void Execute()
        {
            var forecastDto = new WeatherForecastDto();

        CityNameReading:
            Console.Write("Enter city name:");
            forecastDto.CityName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(forecastDto.CityName))
            {
                Console.WriteLine("Wrong or empty input! Please, try again.");
                goto CityNameReading;
            }

            forecastDto.DaysCount = 1;

            try
            {
                forecastDto = _weatherService.GetWeatherForecast(forecastDto).GetAwaiter().GetResult();
            }
            catch (System.Net.WebException)
            {
                throw new System.Net.WebException("Can't find city with such name.");
            }

            _weatherForecastViewer.ShowWeatherForecast(forecastDto);
        }
    }
}