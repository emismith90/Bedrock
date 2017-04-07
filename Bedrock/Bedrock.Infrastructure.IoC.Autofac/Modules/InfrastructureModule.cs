using Microsoft.Extensions.Caching.Memory;
using Autofac;
using Bedrock.Infrastructure.Caching.Abstract;
using Bedrock.Infrastructure.Caching.Memory;
using Bedrock.Infrastructure.Configuration;
using Bedrock.Infrastructure.Configuration.Options;
using Bedrock.Infrastructure.Logger;

namespace Bedrock.Infrastructure.IoC.Autofac.Modules
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Configuration
            builder.RegisterType<AppSettings>()
               .As<IAppSetting>()
               .SingleInstance();

            builder.RegisterType<ConnectionStringsOptions>()
                .SingleInstance();
            builder.RegisterType<LoggingOptions>()
                .SingleInstance();
            builder.RegisterType<CachingOptions>()
                .SingleInstance();

            // Logging
            builder.RegisterType<BedrockLogManager>()
                 .As<IBedrockLogManager>()
                 .SingleInstance();
            
            // Caching
            builder.RegisterType<MemoryCache>()
               .As<IMemoryCache>()
               .SingleInstance();

            builder.RegisterType<BedrockMemoryCache>()
               .As<IBedrockCache>()
               .SingleInstance();
        }
    }
}
