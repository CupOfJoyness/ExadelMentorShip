namespace DataLayer.Models.JSON
{
    public class WeatherForecastResponse
    {
        public City city;
        public WeatherForecastList[] list;
    }

    public class WeatherForecastList
    {
        public long dt;
        public ForecastTemperature temp;
        public WeatherDescription[] weather;
    }

    public class City
    {
        public string name;
    }
}
