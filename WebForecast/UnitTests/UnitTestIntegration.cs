using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Services;
using DataLayer.Repositories;
using System.Threading.Tasks;
using PresentationLayer.Mappings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTestIntegration
    {
        private readonly IMapper _mapper;
        private readonly IWeatherService _weatherService;
        public UnitTestIntegration()
        {
            var weatherRepository = new WeatherRepository();
            _mapper = MappingConfiguration.GetMapperCongiguration().CreateMapper();

            _weatherService = new WeatherService(_mapper, weatherRepository);
        }
        [TestMethod]
        public async Task ForecastReturnNullIfEnterNull()
        {
            var forecastDto = new WeatherForecastDto();
            forecastDto.CityName = string.Empty;
            forecastDto.DaysCount = 1;

            var actualResult = await _weatherService.GetWeatherForecast(forecastDto);

            Assert.IsNull(actualResult);
        }

        [TestMethod]
        public async Task ForecastReturnRightCityValue()
        {
            var forecastDto = new WeatherForecastDto();
            forecastDto.CityName = "Brest";
            forecastDto.DaysCount = 1;

            var actualResult = await _weatherService.GetWeatherForecast(forecastDto);

            Assert.AreEqual(forecastDto.CityName, actualResult.CityName);
        }
    }
}