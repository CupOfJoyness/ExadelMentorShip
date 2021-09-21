using System;

namespace BusinessLayer.DTO
{
    public class WeatherDto
    {
        public string CityName { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string FullDescription { get; set; }
        public double DayTemperature { get; set; }
    }
}