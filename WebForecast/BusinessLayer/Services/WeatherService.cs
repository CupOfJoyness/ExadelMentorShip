using System;
using Newtonsoft.Json;
using DataLayer.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _weatherRepository;
        public WeatherService(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        public async Task<WeatherResponse> GetWeather(CityInfo cityInfo)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(cityInfo);
            if (!Validator.TryValidateObject(cityInfo, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            if (string.IsNullOrWhiteSpace(cityInfo.CityName))
            {
                return null;
            }

            var answer = await _weatherRepository.GetWeather(cityInfo.CityName);
            WeatherResponse response_global = JsonConvert.DeserializeObject<WeatherResponse>(answer);
            return response_global;
        }
    }
}