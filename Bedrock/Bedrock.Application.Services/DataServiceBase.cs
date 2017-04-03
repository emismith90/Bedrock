using Microsoft.Extensions.Caching.Memory;
using AutoMapper;
using Bedrock.Domain.Abstract.UoW;

namespace Bedrock.Application.Services
{
    public abstract class DataServiceBase : ServiceBase
    {
        protected readonly IMapper Mapper;
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMemoryCache Cache;

        public DataServiceBase(IMapper mapper, IUnitOfWork unitOfWork, IMemoryCache cache) : base()
        {
            this.Mapper = mapper;
            this.UnitOfWork = unitOfWork;
        }
    }
}
