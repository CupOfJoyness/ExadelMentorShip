using AutoMapper;
using System.Collections.Generic;


namespace PresentationLayer.Mappings
{
    public static class PresentationMapperConfiguration
    {
        public static MapperConfiguration GetMapperCongiguration()
        {
            var mapperProfiles = new List<Profile>
            {
                new TestMappingProfile()
            };
            return new MapperConfiguration(mc => mc.AddProfiles(mapperProfiles));
        }
    }
}
