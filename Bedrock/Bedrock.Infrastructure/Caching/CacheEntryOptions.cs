using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Infrastructure.Caching
{
    public class CacheEntryOptions
    {
        public DateTimeOffset? AbsoluteExpiration { get; set; }
        public TimeSpan? AbsoluteExpirationRelativeToNow { get; set; }
        public TimeSpan? SlidingExpiration { get; set; }
        public bool NeverRemove { get; set; }
    }
}
