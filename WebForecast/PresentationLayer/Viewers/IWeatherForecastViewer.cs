using BusinessLayer.DTO;

namespace PresentationLayer.Viewers
{
    public interface IWeatherForecastViewer
    {
        void ShowWeatherForecast(WeatherForecastDto forecastDto);
        void ShowHottestCity(string hottestCity, long timeDelay);
    }
}