using Bedrock.Infrastructure.Caching.Abstract;
using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Bedrock.Infrastructure.Caching.Memory
{
    public class BedrockMemoryCache : MemoryCache, IBedrockCache
    {
        public BedrockMemoryCache(IOptions<MemoryCacheOptions> optionsAccessor) : base(optionsAccessor)
        {

        }
    }
}
