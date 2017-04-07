using System.Runtime.CompilerServices;

namespace Bedrock.Infrastructure.Configuration.Options
{
    public class ConnectionStringsOptions : OptionsBase
    {
        public ConnectionStringsOptions(IAppSetting appSettings) : base(appSettings)
        {
        }

        public string BedrockConnection => GetString();
    }
}
