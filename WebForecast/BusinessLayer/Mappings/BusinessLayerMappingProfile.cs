using AutoMapper;
using BusinessLayer.DTO;
using DataLayer.Models;

namespace BusinessLayer.Mappings
{
    public class BusinessLayerMappingProfile : Profile
    {
        public BusinessLayerMappingProfile()
        {
            CreateMap<Weather, WeatherDto>().ReverseMap();

            CreateMap<WeatherForecast, WeatherForecastDto>().ReverseMap();
        }
    }
}