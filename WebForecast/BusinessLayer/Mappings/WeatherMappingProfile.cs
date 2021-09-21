using System;
using AutoMapper;
using System.Linq;
using BusinessLayer.DTO;
using BusinessLayer.DTO.JSON;

namespace BusinessLayer.Mappings
{
    public class WeatherMappingProfile : Profile
    {
        public WeatherMappingProfile()
        {
            CreateMap<WeatherForecastJsonDto, WeatherDto>()
                .ForMember(dest
                    => dest.Date, opt
                    => opt.MapFrom(src => new DateTime(1970, 01, 01).AddSeconds(src.dt)))
                .ForMember(dest
                    => dest.DayTemperature, opt
                    => opt.MapFrom(src => src.temp.day))
                .ForMember(dest
                    => dest.Description, opt
                    => opt.MapFrom(src => src.weather.First().main))
                .ForMember(dest
                    => dest.FullDescription, opt
                    => opt.MapFrom(src => src.weather.First().description));

            CreateMap<WeatherForecastResponse, WeatherForecastDto>()
                .ForMember(dest
                    => dest.CityName, opt
                    => opt.MapFrom(src => src.city.name))
                .ForMember(dest
                    => dest.DaysCount, opt
                    => opt.MapFrom(src => src.list.Length))
                .ForMember(dest
                    => dest.Weather, opt
                    => opt.MapFrom(src => src.list.ToList()));

            CreateMap<WeatherJsonDto, WeatherDto>()
                .ForMember(dest
                    => dest.CityName, opt
                    => opt.MapFrom(src => src.name))
                .ForMember(dest
                    => dest.Date, opt
                    => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest
                    => dest.DayTemperature, opt
                    => opt.MapFrom(src => src.main.temp))
                .ForMember(dest
                    => dest.Description, opt
                    => opt.MapFrom(src => src.weather.First().main))
                .ForMember(dest
                    => dest.FullDescription, opt
                    => opt.MapFrom(src => src.weather.First().description));
        }
    }
}