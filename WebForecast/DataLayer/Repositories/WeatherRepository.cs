using System;
using System.IO;
using AutoMapper;
using System.Net;
using Newtonsoft.Json;
using DataLayer.Models;
using DataLayer.Models.JSON;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DataLayer.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        const string AppId = "23a60ff5ee6fce381a222b1173ea24e1";

        private readonly IMapper _mapper;

        public WeatherRepository(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<WeatherForecast> GetWeatherForecastAsync(string cityName, int daysCount, string forecastLanguage = "en", string unitsSystem = "metric")
        {
            if (string.IsNullOrWhiteSpace(cityName)) throw new ArgumentException(nameof(cityName));
            if (daysCount is < 0 or > 16) throw new ArgumentException(nameof(daysCount));

            var request = WebRequest.Create($"https://api.openweathermap.org/data/2.5/forecast/daily?q="
                                                   + cityName
                                                   + $"&units={unitsSystem}"
                                                   + $"&cnt={daysCount}"
                                                   + $"&lang={forecastLanguage}"
                                                   + $"&appid={AppId}");
            request.Method = "POST";

            var response = await request.GetResponseAsync();

            string answer = string.Empty;

            await using (Stream s = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(s))
                {
                    answer = await reader.ReadToEndAsync();
                }
            }

            response.Close();

            var forecastResponseGlobal = JsonConvert.DeserializeObject<WeatherForecastResponse>(answer);

            return _mapper.Map<WeatherForecast>(forecastResponseGlobal);

        }

        public async Task<WeatherForecast> GetWeatherForNowAsync(string cityName, string forecastLanguage = "en", string unitsSystem = "metric")
        {
            if (string.IsNullOrWhiteSpace(cityName)) throw new ArgumentException(nameof(cityName));

            var request = WebRequest.Create($"https://api.openweathermap.org/data/2.5/weather?q="
                                            + cityName
                                            + $"&units={unitsSystem}"
                                            + $"&lang={forecastLanguage}"
                                            + $"&appid={AppId}");
            request.Method = "POST";

            WebResponse response;

            try
            {
                response = await request.GetResponseAsync();
            }
            catch (WebException)
            {
                throw new WebException(cityName);
            }

            string answer = string.Empty;

            await using (Stream s = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(s))
                {
                    answer = await reader.ReadToEndAsync();
                }
            }

            response.Close();

            var forecastResponse = JsonConvert.DeserializeObject<WeatherForNowResponce>(answer);
            var weather = _mapper.Map<Weather>(forecastResponse);

            return new WeatherForecast()
            {
                DaysCount = 1,
                CityName = weather.CityName,
                Weather = new List<Weather> {weather}
            };
        }
    }
}