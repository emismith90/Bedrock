using AutoMapper;
using Bedrock.Mapper.Profiles;

namespace Bedrock.Mapper
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
