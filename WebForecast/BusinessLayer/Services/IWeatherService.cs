using System.Threading.Tasks;
using BusinessLayer.DTO;

namespace BusinessLayer.Services
{
    public interface IWeatherService
    {
        Task<WeatherForecastDto> GetWeatherForecast(WeatherForecastDto forecastDto);
    }
}