using Moq;
using BusinessLayer.Services;
using DataLayer.Repositories;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer.Mappings;
using AutoMapper;
using BusinessLayer.DTO;

namespace UnitTests
{
    [TestClass]
    public class UnitTestMock
    {
        private readonly IMapper _mapper;
        private readonly IWeatherService _weatherService;
        public UnitTestMock()
        {
            var weatherRepositoryMock = new Mock<IWeatherRepository>();
            _mapper = MappingConfiguration.GetMapperCongiguration().CreateMapper();
            _weatherService = new WeatherService(_mapper, weatherRepositoryMock.Object);
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
    }
}