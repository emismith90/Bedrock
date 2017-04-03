using AutoMapper;
using Bedrock.Domain.Data.Models;
using Bedrock.Application.Model;

namespace Bedrock.Application.Mapper.Profiles
{
    public class TodoMappingProfile : Profile
    {
        public TodoMappingProfile()
        {
            this.CreateMap<TodoEntity, TodoModel>().ReverseMap();
        }
    }
}
