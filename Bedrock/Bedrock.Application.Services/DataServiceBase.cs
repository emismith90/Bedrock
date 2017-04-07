using Microsoft.Extensions.Caching.Memory;
using AutoMapper;
using Bedrock.Domain.Abstract.UoW;
using Bedrock.Infrastructure.Caching.Abstract;

namespace Bedrock.Application.Services
{
    public abstract class DataServiceBase : ServiceBase
    {
        protected readonly IMapper Mapper;
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IBedrockCache Cache;

        public DataServiceBase(IMapper mapper, IUnitOfWork unitOfWork, IBedrockCache cache) : base()
        {
            this.Mapper = mapper;
            this.UnitOfWork = unitOfWork;
            this.Cache = cache;
        }
    }
}
