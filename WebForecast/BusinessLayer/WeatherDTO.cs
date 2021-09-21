namespace BusinessLayer
{
    public class WeatherResponse
    {
        public string name;
        public WeatherNow[] weather;
        public MainNow main;
    }

    public class WeatherNow
    {
        public string main;
        public string description;
    }

    public class MainNow
    {
        public double temp;
        public string feels_like;
        public string temp_min;
        public string temp_max;
        public string pressure;
        public string humidity;
        public string sea_level;
        public string grnd_level;
    }
}
