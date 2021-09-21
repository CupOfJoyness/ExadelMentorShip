using AutoMapper;
using BusinessLayer.Mappings;
using System.Collections.Generic;

namespace PresentationLayer.Mappings
{
    public static class MappingConfiguration
    {
        public static MapperConfiguration GetMapperCongiguration()
        {
            var mapperProfiles = new List<Profile>
            {
                new WeatherMappingProfile()
            };
            return new MapperConfiguration(mc => mc.AddProfiles(mapperProfiles));
        }
    }
}