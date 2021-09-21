using System.Collections.Generic;

namespace BusinessLayer.DTO
{
    public class WeatherForecastDto
    {
        public int DaysCount { get; set; }
        public string CityName { get; set; }
        public List<WeatherDto> Weather { get; set; }
    }
}
