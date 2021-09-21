using System;
using AutoMapper;
using Core.Helpers;
using Newtonsoft.Json;
using BusinessLayer.DTO;
using BusinessLayer.DTO.JSON;
using DataLayer.Repositories;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IMapper _mapper;
        private readonly IWeatherRepository _weatherRepository;
        public WeatherService(IMapper mapper, IWeatherRepository weatherRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _weatherRepository = weatherRepository ?? throw new ArgumentNullException(nameof(weatherRepository));
        }

        public async Task<WeatherForecastDto> GetWeatherForecast(WeatherForecastDto forecastDto)
        {
            if (forecastDto.Equals(null)) throw new ArgumentNullException(nameof(forecastDto));
            if (forecastDto.DaysCount is < 0 or > 16) throw new ArgumentException(nameof(forecastDto.DaysCount));

            ValidationHelper.Validate(forecastDto);

            var answer = await _weatherRepository.GetWeatherForecast(forecastDto.CityName, forecastDto.DaysCount);
            var forecastResponseGlobal = JsonConvert.DeserializeObject<WeatherForecastResponse>(answer);

            return _mapper.Map<WeatherForecastDto>(forecastResponseGlobal);
        }
    }
}