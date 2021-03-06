﻿using AutoMapper;
using Bedrock.Application.Mapper.Profiles;

namespace Bedrock.Application.Mapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new TodoMappingProfile());
            });
        }
    }
}
