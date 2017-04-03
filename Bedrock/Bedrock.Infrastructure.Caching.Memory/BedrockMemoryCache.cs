using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Bedrock.Infrastructure.Caching.Abstract;

namespace Bedrock.Infrastructure.Caching.Memory
{
    public class BedrockMemoryCache : IBedrockCache
    {
        protected readonly IMemoryCache cache;
        public BedrockMemoryCache(IMemoryCache cache)
        {
        }
        public IEnumerable<string> GetAllKeys()
        {
            throw new NotImplementedException();
        }

        public bool TryGet<T>(string key, out T value)
        {
            throw new NotImplementedException();
        }

        public bool Set<T>(string key, T value, string parentKey = null)
        {
            throw new NotImplementedException();
        }
        public bool Set<T>(string key, T value, DateTime expiresAt, string parentKey = null)
        {
            throw new NotImplementedException();
        }
        public bool Set<T>(string key, T value, TimeSpan expiresIn, string parentKey = null)
        {
            throw new NotImplementedException();
        }

        public bool Flush(string key)
        {
            throw new NotImplementedException();
        }
        bool IBedrockCache.FlushAll()
        {
            throw new NotImplementedException();
        }
    }
}
