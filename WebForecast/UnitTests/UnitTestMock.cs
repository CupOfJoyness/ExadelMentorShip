using Moq;
using BusinessLayer.Services;
using DataLayer.Repositories;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer.Mappings;
using AutoMapper;
using BusinessLayer.DTO;
using System;

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
    }
}