using AutoMapper;
using Bedrock.Data.Models;
using Bedrock.Dto;

namespace Bedrock.Mapper.Profiles
{
    public class TodoMappingProfile : Profile
    {
        public TodoMappingProfile()
        {
            this.CreateMap<Todo, TodoDto>().ReverseMap();
        }
    }
}
