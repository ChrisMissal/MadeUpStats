using System.Web.Mvc;
using System.Web.Routing;

namespace MadeUpStats.Web.Routing
{
    public class RouteConfigurator : IRouteConfigurator
    {
        private readonly RouteCollection routes;

        public RouteConfigurator()
        {
            routes = RouteTable.Routes;
        }

        public virtual void RegisterRoutes()
        {
            routes.Clear();
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new {favicon = @"(.*/)?favicon.ico(/.*)?"});

            // Default/fallback route
            routes.MapRoute("Default", "{controller}/{action}/{id}", 
                            new { controller = "Home", action = "Index", id = "" });
        }
    }
}