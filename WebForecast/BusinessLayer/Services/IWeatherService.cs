using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IWeatherService
    {
        Task<WeatherResponse> GetWeather(CityInfo cityName);
    }
}
