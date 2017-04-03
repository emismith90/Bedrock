using System;
using System.Collections.Generic;

namespace Bedrock.Infrastructure.Caching.Abstract
{
    public interface IBedrockCache 
    {
        IEnumerable<string> GetAllKeys();

        bool TryGet<T>(string key, out T value);

        bool Set<T>(string key, T value, string parentKey = null);
        bool Set<T>(string key, T value, DateTime expiresAt, string parentKey = null);
        bool Set<T>(string key, T value, TimeSpan expiresIn, string parentKey = null);

        bool Flush(string key);
        bool FlushAll();
    }
}
