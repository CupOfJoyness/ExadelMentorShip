using BusinessLayer.DTO;

namespace PresentationLayer.Viewers
{
    public interface IWeatherForecastViewer
    {
        void ShowWeatherForecast(WeatherForecastDto forecastDto);
    }
}