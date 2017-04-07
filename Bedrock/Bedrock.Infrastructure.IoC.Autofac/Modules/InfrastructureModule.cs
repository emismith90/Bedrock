using Microsoft.Extensions.Caching.Memory;
using Autofac;
using Bedrock.Infrastructure.Caching.Abstract;
using Bedrock.Infrastructure.Caching.Memory;
using Bedrock.Infrastructure.Configuration;
using Bedrock.Infrastructure.Configuration.Options;

namespace Bedrock.Infrastructure.IoC.Autofac.Modules
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MemoryCache>()
               .As<IMemoryCache>()
               .SingleInstance();

            builder.RegisterType<BedrockMemoryCache>()
               .As<IBedrockCache>()
               .SingleInstance();

            var appSettings = new AppSettings();
            builder.RegisterInstance(appSettings)
               .As<IAppSetting>()
               .SingleInstance();

            builder.RegisterType<CachingOptions>()
                .SingleInstance();

            builder.RegisterType<ConnectionStringsOptions>()
                .SingleInstance();
        }
    }
}
