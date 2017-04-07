using Microsoft.Extensions.Configuration;

namespace Bedrock.Infrastructure.Configuration
{
    public interface IAppSetting
    {
        string Get(string key);
        IConfigurationSection GetSection(string section);
    }
}
