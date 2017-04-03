using Autofac;
using Bedrock.Domain.Data.Contexts;
using Bedrock.Domain.EF.Repositories;
using Bedrock.Domain.EF.UoW;
using Bedrock.Domain.Abstract.Repositories;
using Bedrock.Domain.Abstract.UoW;

namespace Bedrock.Infrastructure.IoC.Autofac.Modules
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.Load(new System.Reflection.AssemblyName("Bedrock.Domain.Abstract")), System.Reflection.Assembly.Load(new System.Reflection.AssemblyName("Bedrock.Domain.EF")))
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
