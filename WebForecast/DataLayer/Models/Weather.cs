using System;

namespace DataLayer.Models
{
    public class Weather
    {
        public DateTime Date { get; set; }
        public string CityName { get; set; }
        public string Description { get; set; }
        public double DayTemperature { get; set; }
        public string FullDescription { get; set; }
    }
}
