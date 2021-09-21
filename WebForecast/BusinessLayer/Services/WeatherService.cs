using System;
using AutoMapper;
using Newtonsoft.Json;
using BusinessLayer.DTO.JSON;
using DataLayer.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BusinessLayer.DTO;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace BusinessLayer.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IMapper _mapper;
        private readonly IWeatherRepository _weatherRepository;
        public WeatherService(IWeatherRepository weatherRepository, IMapper mapper)
        {
            _weatherRepository = weatherRepository;
            _mapper = mapper;
        }

        public async Task<WeatherDto> GetWeatherForNow(WeatherForecastDto forecastDto)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(forecastDto);

            if (!Validator.TryValidateObject(forecastDto, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            if (string.IsNullOrWhiteSpace(forecastDto.CityName))
            {
                return null;
            }

            var answer = await _weatherRepository.GetWeather(forecastDto.CityName);
            WeatherJsonDto forecastResponseGlobal = JsonConvert.DeserializeObject<WeatherJsonDto>(answer);

            return _mapper.Map<WeatherDto>(forecastResponseGlobal);
        }

        public async Task<WeatherForecastDto> GetWeatherForecast(WeatherForecastDto forecastDto)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(forecastDto);
            if (!Validator.TryValidateObject(forecastDto, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            if (string.IsNullOrWhiteSpace(forecastDto.CityName))
            {
                return null;
            }

            var answer = await _weatherRepository.GetWeatherForecast(forecastDto.CityName, forecastDto.DaysCount);
            WeatherForecastResponse forecastResponseGlobal = JsonConvert.DeserializeObject<WeatherForecastResponse>(answer);

            return _mapper.Map<WeatherForecastDto>(forecastResponseGlobal);
        }
    }
}