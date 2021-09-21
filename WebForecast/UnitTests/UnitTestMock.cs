using Moq;
using BusinessLayer;
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
        private readonly IWeatherService _weatherService;
        private readonly IMapper _mapper;
        public UnitTestMock()
        {
            var weatherRepositoryMock = new Mock<IWeatherRepository>();
            _mapper = PresentationMapperConfiguration.GetMapperCongiguration().CreateMapper();
            _weatherService = new WeatherService(weatherRepositoryMock.Object, _mapper);
        }

        [TestMethod]
        public async Task ForecastReturnNullIfEnterNull()
        {
            var forecastDto = new WeatherForecastDto();
            forecastDto.CityName = string.Empty;

            var actualResult = await _weatherService.GetWeatherForNow(forecastDto);
            
            Assert.IsNull(actualResult);
        }
    }
}