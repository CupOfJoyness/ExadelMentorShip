using System;
using System.Linq;
using AutoMapper;
using DataLayer.Models;
using DataLayer.Models.JSON;

namespace DataLayer.Mappings
{
    public class DataLayerMappingProfile : Profile
    {
        public DataLayerMappingProfile()
        {
            CreateMap<WeatherForecastList, Weather>()
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

            CreateMap<WeatherForecastResponse, WeatherForecast>()
                .ForMember(dest
                    => dest.CityName, opt
                    => opt.MapFrom(src => src.city.name))
                .ForMember(dest
                    => dest.DaysCount, opt
                    => opt.MapFrom(src => src.list.Length))
                .ForMember(dest
                    => dest.Weather, opt
                    => opt.MapFrom(src => src.list.ToList()));

            CreateMap<WeatherForNowResponce, Weather>()
                .ForMember(dest
                    => dest.Date, opt
                    => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest
                    => dest.CityName, opt
                    => opt.MapFrom(src => src.name))
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