using Autofac;
using Bedrock.Infrastructure.Caching.Abstract;
using Bedrock.Infrastructure.Caching.Memory;
using Microsoft.Extensions.Caching.Memory;

namespace Bedrock.Infrastructure.IoC.Autofac.Modules
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IMemoryCache>()
               .As<MemoryCache>()
               .SingleInstance();

            builder.RegisterType<BedrockMemoryCache>()
               .As<IBedrockCache>();
        }
    }
}
