using System.Web.Mvc;
using System.Web.Routing;
using MadeUpStats.Web.Controllers;
using MvcContrib.Routing;

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

            MvcRoute.MappUrl("")
                    .ToDefaultAction<HomeController>(x => x.Index())
                    .WithConstraints(new { controller = "Home", action = "Index" })
                    .AddWithName("Home-Index", routes);
            MvcRoute.MappUrl("Tags")
                    .ToDefaultAction<TagsController>(x => x.Index())
                    .WithConstraints(new { controller = "Tags" })
                    .AddWithName("Tags-Index", routes);
            MvcRoute.MappUrl("{action}")
                    .ToDefaultAction<HomeController>(x => x.Information())
                    .WithConstraints(new {controller = "Home"})
                    .AddWithName("Home-Information", routes);

            MvcRoute.MappUrl("{controller}/{action}")
                    .ToDefaultAction<StatController>(x => x.Create())
                    .WithConstraints(new { controller = "Stat", action = "Create" })
                    .AddWithName("Stat", routes);
            MvcRoute.MappUrl("{controller}/{id}")
                    .ToDefaultAction<StatController>(x => x.Index(0))
                    .WithConstraints(new { controller = "Stat", action = "Index" })
                    .AddWithName("Stat-Index", routes);

            MvcRoute.MappUrl("{controller}/{tagString}")
                    .ToDefaultAction<TagsController>(x => x.Index(""))
                    .WithConstraints(new { controller = "Tags" })
                    .AddWithName("Tags-Index-tagString", routes);

            // Default/fallback route
            routes.MapRoute("Default", "{controller}/{action}/{id}",
                            new { controller = "Home", action = "Index", id = "" });
        }
    }
}