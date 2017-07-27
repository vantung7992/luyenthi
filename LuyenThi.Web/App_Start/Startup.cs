using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using LuyenThi.Data;
using LuyenThi.Data.Infrastructure;
using LuyenThi.Data.Repositories;
using LuyenThi.Service;
using Microsoft.Owin;
using Owin;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(LuyenThi.Web.App_Start.Startup))]

namespace LuyenThi.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigAutofac(app);
        }

        private void ConfigAutofac(IAppBuilder app)
        {
            var buider = new ContainerBuilder();
            buider.RegisterControllers(Assembly.GetExecutingAssembly());
            buider.RegisterApiControllers(Assembly.GetExecutingAssembly());
            buider.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            buider.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            buider.RegisterType<LuyenthiDBContext>().AsSelf().InstancePerRequest();

            //Repository
            buider.RegisterAssemblyTypes(typeof(CauhoiRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            //Service
            buider.RegisterAssemblyTypes(typeof(CauhoiService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            Autofac.IContainer container = buider.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        }
    }
}