using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IWeatherRepository
    {
        Task<string> GetWeather(string cityName, string forecastLanguage = "en", string unitsSystem = "metric");
        Task<string> GetWeatherForecast(string cityName, int daysCount, string forecastLanguage = "en", string unitsSystem = "metric");
    }
}