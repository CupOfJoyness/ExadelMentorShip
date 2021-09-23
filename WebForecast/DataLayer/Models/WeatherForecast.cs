using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class WeatherForecast
    {
        public int DaysCount { get; set; }
        [Required]
        public string CityName { get; set; }
        public List<Weather> Weather { get; set; }
    }
}
