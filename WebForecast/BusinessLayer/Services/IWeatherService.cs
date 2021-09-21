using System.Threading.Tasks;
using BusinessLayer.DTO;
using BusinessLayer.DTO.JSON;

namespace BusinessLayer.Services
{
    public interface IWeatherService
    {
        Task<WeatherDto> GetWeatherForNow(WeatherForecastDto forecastDto);
        Task<WeatherForecastDto> GetWeatherForecast(WeatherForecastDto forecastDto);
    }
}