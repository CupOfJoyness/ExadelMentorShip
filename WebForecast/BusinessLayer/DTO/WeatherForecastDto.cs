using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DTO
{
    public class WeatherForecastDto
    {
        public int DaysCount { get; set; }
        [Required]
        public string CityName { get; set; }
        public List<WeatherDto> Weather { get; set; }
    }
}
