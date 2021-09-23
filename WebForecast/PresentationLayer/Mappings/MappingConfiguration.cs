using AutoMapper;
using DataLayer.Mappings;
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
                new BusinessLayerMappingProfile(),
                new DataLayerMappingProfile()
            };
            return new MapperConfiguration(mc => mc.AddProfiles(mapperProfiles));
        }
    }
}