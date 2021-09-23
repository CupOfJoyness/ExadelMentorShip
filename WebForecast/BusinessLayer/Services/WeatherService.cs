using System;
using AutoMapper;
using System.Linq;
using Core.Helpers;
using BusinessLayer.DTO;
using System.Diagnostics;
using DataLayer.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using System.Xml.Linq;

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

        public async Task<WeatherForecastDto> GetWeatherForNowAsync(string cityName)
        {
            if (string.IsNullOrWhiteSpace(cityName)) throw new ArgumentNullException(nameof(cityName));

            var weatherForecast = await _weatherRepository.GetWeatherForNowAsync(cityName);

            return _mapper.Map<WeatherForecastDto>(weatherForecast);
        }

        public async Task<WeatherForecastDto> GetWeatherForecastAsync(WeatherForecastDto forecastDto)
        {
            if (forecastDto.Equals(null)) throw new ArgumentNullException(nameof(forecastDto));
            if (forecastDto.DaysCount is < 0 or > 16) throw new ArgumentException(nameof(forecastDto.DaysCount));

            ValidationHelper.Validate(forecastDto);

            var weatherForecast = await _weatherRepository.GetWeatherForecastAsync(forecastDto.CityName, forecastDto.DaysCount);

            return _mapper.Map<WeatherForecastDto>(weatherForecast);
        }

        public async Task<(string, long)> GetHottestCityAsync(List<string> cityNames)
        {
            if (cityNames.Equals(null)) throw new ArgumentNullException(nameof(cityNames));
            if (!cityNames.Any()) throw new ArgumentException(nameof(cityNames));

            var resultTempList = new Dictionary<string, double>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var cityName in cityNames)
            {
                try
                {
                    var forecast = await GetWeatherForNowAsync(cityName);

                    resultTempList.Add(forecast.CityName, forecast.Weather.First().DayTemperature);
                }
                catch (WebException name)
                {
                    //TODO:Added wrong cities list
                    //Console.WriteLine($"Can't find city with such name: {cityName}.");
                }
            }

            double maxTemp = double.MinValue;
            string maxTempCity = string.Empty;

            foreach (var temp in resultTempList)
            {
                if (maxTemp < temp.Value)
                {
                    maxTempCity = temp.Key;
                }
            }

            stopwatch.Stop();

            return (maxTempCity, stopwatch.ElapsedMilliseconds);
        }
    }
}