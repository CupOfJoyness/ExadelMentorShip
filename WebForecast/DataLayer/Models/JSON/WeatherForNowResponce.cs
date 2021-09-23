namespace DataLayer.Models.JSON
{
    public class WeatherForNowResponce
    {
        public string name;
        public WeatherDescription[] weather;
        public WeatherForNow main;
    }

    public class WeatherForNow
    {
        public double temp;
        //public string feels_like;
        //public string temp_min;
        //public string temp_max;
        //public string pressure;
        //public string humidity;
        //public string sea_level;
        //public string grnd_level;
    }
}
