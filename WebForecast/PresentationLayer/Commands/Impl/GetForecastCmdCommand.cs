using System;
using BusinessLayer.DTO;
using BusinessLayer.Services;
using System.Threading.Tasks;
using PresentationLayer.Viewers;

namespace PresentationLayer.Commands.Impl
{
    public class GetForecastCmdCommand : BaseCmdCommand
    {
        private readonly IWeatherService _weatherService;
        private readonly IWeatherForecastViewer _weatherForecastViewer;

        public GetForecastCmdCommand(IWeatherService weatherService, IWeatherForecastViewer weatherForecastViewer)
        {
            _weatherService = weatherService ?? throw new ArgumentNullException(nameof(weatherService));
            _weatherForecastViewer = weatherForecastViewer ?? throw new ArgumentNullException(nameof(weatherForecastViewer));
        }

        protected override string CommandPattern => "2";
        public override string CommandMessange => "2.Forecast for a few days.";

        protected override void Execute()
        {
            int daysCount;
            var forecastDto = new WeatherForecastDto();

            CityNameReading:

            Console.Write("Enter city name:");
            forecastDto.CityName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(forecastDto.CityName))
            {
                Console.WriteLine("Wrong or empty input! Please, try again.");
                goto CityNameReading;
            }

            DaysCountReading:

            Console.Write("Enter forecast days count,more than 0 but lower than 16:");

            if (!int.TryParse(Console.ReadLine(), out daysCount) || daysCount is < 1 or > 16)
            {
                Console.WriteLine("Wrong or empty input! Please, try again. The value must be more that 0 and lower than 16.");
                goto DaysCountReading;
            }

            forecastDto.DaysCount = daysCount;

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