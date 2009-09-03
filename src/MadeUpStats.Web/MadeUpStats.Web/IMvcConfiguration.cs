using System.Web.Mvc;
using MadeUpStats.Web.Routing;

namespace MadeUpStats.Web
{
    public interface IMvcConfiguration
    {
        IRouteConfigurator GetRouteConfigurator();

        IViewEngine GetViewEngine();

        IControllerFactory GetControllerFactory();
    }
}