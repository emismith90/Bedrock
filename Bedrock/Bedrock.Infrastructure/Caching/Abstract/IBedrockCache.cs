using System;
using System.Collections.Generic;

namespace Bedrock.Infrastructure.Caching.Abstract
{
    public interface IBedrockCache 
    {
        IList<string> GetAllKeys();
        IList<string> FindKeys(string startWith);

        T Get<T>(string key);
        bool TryGet<T>(string key, out T value);

        bool Set<T>(string key, T value);
        bool Set<T>(string key, T value, DateTime expiresAt);
        bool Set<T>(string key, T value, TimeSpan expiresIn);
        bool Set<T>(string key, T value, CacheEntryOptions options);

        void Flush(string key);
        void FlushAll();
    }
}
