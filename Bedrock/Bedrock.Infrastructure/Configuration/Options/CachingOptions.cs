using Bedrock.Infrastructure.Extensions;

namespace Bedrock.Infrastructure.Configuration.Options
{
    public class CachingOptions : OptionsBase
    {
        public CachingOptions(IAppSetting appSettings) : base(appSettings)
        {
        }

        public int ExpiredInMinute => GetInt().Default(5);
        public int SlidingInMinute => GetInt().Default(1);

        public int RetryInSecond => GetInt().Default(10);
    }
}
