using BusinessLayer;
using BusinessLayer.Services;
using DataLayer.Repositories;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer.DI;
using PresentationLayer.Mappings;
using BusinessLayer.DTO;

namespace UnitTests
{
    [TestClass]
    public class UnitTestIntegration
    {
        private readonly IWeatherService _weatherService;
        private readonly IMapper _mapper;
        public UnitTestIntegration()
        {
            IWeatherRepository weatherRepository = new WeatherRepository();
            _mapper = PresentationMapperConfiguration.GetMapperCongiguration().CreateMapper();

            _weatherService = new WeatherService(weatherRepository, _mapper);
        }
        [TestMethod]
        public async Task ForecastReturnNullIfEnterNull()
        {
            var forecastDto = new WeatherForecastDto();
            forecastDto.CityName = string.Empty;

            var actualResult = await _weatherService.GetWeatherForNow(forecastDto);

            Assert.IsNull(actualResult);
        }

        [TestMethod]
        public async Task ForecastReturnRightCityValue()
        {
            var forecastDto = new WeatherForecastDto();
            forecastDto.CityName = "Brest";

            var actualResult = await _weatherService.GetWeatherForNow(forecastDto);

            Assert.AreEqual(forecastDto.CityName, actualResult.CityName);
        }
    }
}