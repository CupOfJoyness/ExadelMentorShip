using System;
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
            var forecastDto = new WeatherForecastDto
            {
                CityName = string.Empty,
                DaysCount = 1
            };
            string actualResult = null;

            try
            {
                await _weatherService.GetWeatherForecast(forecastDto);
            }
            catch (ArgumentException e)
            {
                actualResult = e.Message;
            }

            Assert.AreEqual(actualResult?.ToLower().Contains("city"), true);
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

        [TestMethod]
        public async Task ForecastReturnRightCityQuantity()
        {
            var forecastDto = new WeatherForecastDto();
            var actualResult = true;

            forecastDto.CityName = "Brest";
            forecastDto.DaysCount = 1;

            for (int i = 1; i < 16; i++)
            {
                forecastDto.DaysCount = i;
                var forecastResult = await _weatherService.GetWeatherForecast(forecastDto);

                if (!forecastResult.Weather.Count.Equals(forecastDto.DaysCount)) 
                    actualResult = false;
            }

            Assert.AreEqual(actualResult, true);
        }
    }
}