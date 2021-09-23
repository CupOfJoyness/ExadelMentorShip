using DataLayer.Models;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IWeatherRepository
    {
        Task<WeatherForecast> GetWeatherForecastAsync(string cityName, int daysCount, string forecastLanguage = "en", string unitsSystem = "metric");
        Task<WeatherForecast> GetWeatherForNowAsync(string cityName, string forecastLanguage = "en", string unitsSystem = "metric");
    }
}