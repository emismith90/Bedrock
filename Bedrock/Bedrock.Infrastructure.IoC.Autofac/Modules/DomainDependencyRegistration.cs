using Autofac;
using Bedrock.Data.Contexts;
using Bedrock.Domain.EF.Repositories;
using Bedrock.Domain.EF.UoW;
using Bedrock.Domain.Repositories;
using Bedrock.Domain.UoW;

namespace Bedrock.Infrastructure.IoC.Autofac.Modules
{
    public class DomainDependencyRegistration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.Load(new System.Reflection.AssemblyName("Bedrock.Domain")), System.Reflection.Assembly.Load(new System.Reflection.AssemblyName("Bedrock.Domain.EF")))
                 .Where(t => t.Name.EndsWith("Repository"))
                 .AsImplementedInterfaces()
                 .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(GenericRepository<,>))
                        .As(typeof(IGenericRepository<,>))
                        .InstancePerDependency();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>();
            builder.RegisterType(typeof(BedrockContext))
                .InstancePerLifetimeScope();
        }
    }
}
