namespace BusinessLayer.DTO.JSON
{
    public class WeatherForecastResponse
    {
        //public string name;
        public City city;
        public WeatherForecastJsonDto[] list;
    }

    public class City
    {
        public string name;
    }

    public class WeatherForecastJsonDto
    {
        public long dt;
        public ForecastTemperature temp;
        public WeatherDescription[] weather;
    }


}
