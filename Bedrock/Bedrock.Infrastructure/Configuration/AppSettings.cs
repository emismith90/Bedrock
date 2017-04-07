using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bedrock.Infrastructure.Configuration
{
    public class AppSettings : IAppSetting
    {
        protected IConfiguration Configuration;
        public AppSettings()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public string Get(string key)
        {
            return Configuration[key];
        }

        public IConfigurationSection GetSection(string section)
        {
            return Configuration.GetSection(section);
        }
    }
}
