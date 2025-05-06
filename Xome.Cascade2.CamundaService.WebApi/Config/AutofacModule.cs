using Autofac;
using LazyProxy.Autofac;
using Xome.Cascade2.CamundaService.Application.Services;
using Xome.Cascade2.CamundaService.Domain.Interfaces;
using Xome.Cascade2.CamundaService.Infrastructure.UnitOfWork;

namespace Xome.Cascade2.CamundaService.WebApi.Config
{
    public class AutofacModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterLazy<IUnitOfWork, UnitOfWork>().InstancePerLifetimeScope();
            // builder.RegisterLazy<IUserService, UserService>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
