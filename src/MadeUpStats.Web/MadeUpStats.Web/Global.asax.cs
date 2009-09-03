using System.Web;
using System.Web.Mvc;

namespace MadeUpStats.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var configuration = Bootstrapper.Container.GetInstance<IMvcConfiguration>();

            var routeConfigurator = configuration.GetRouteConfigurator();
            routeConfigurator.RegisterRoutes();

            var viewEngine = configuration.GetViewEngine();
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(viewEngine);

            var controllerFactory = configuration.GetControllerFactory();
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}