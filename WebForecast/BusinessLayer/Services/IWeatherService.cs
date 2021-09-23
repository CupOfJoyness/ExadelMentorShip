using BusinessLayer.DTO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BusinessLayer.Services
{
    public interface IWeatherService
    {
        Task<WeatherForecastDto> GetWeatherForNowAsync(string cityName);
        Task<WeatherForecastDto> GetWeatherForecastAsync(WeatherForecastDto forecastDto);
        Task<(string, long)> GetHottestCityAsync(List<string> cityNames);
    }
}