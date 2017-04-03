using Autofac;
using Bedrock.Application.Mapper;

namespace Bedrock.Infrastructure.IoC.Autofac.Modules
{
    public class ApplicationDependencyRegistration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.Load(new System.Reflection.AssemblyName("Bedrock.Application.Services.Abstract")), System.Reflection.Assembly.Load(new System.Reflection.AssemblyName("Bedrock.Application.Services")))
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            // automapper
            var mapperConfig = AutoMapperConfig.RegisterMappings();
            builder.RegisterInstance(mapperConfig.CreateMapper());
        }
    }
}
