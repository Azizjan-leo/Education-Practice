using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using NLayerApp.BLL.Infrastructure;
using NLayerApp.WEB.App_Start;
using NLayerApp.WEB.Util;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NLayerApp.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutomapperConfig.Configure();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // внедрение зависимостей
            NinjectModule leaseModule = new LeaseModule();
            NinjectModule serviceModule = new ServiceModule("DefaultConnection");
            var kernel = new StandardKernel(leaseModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

        }
    }
}