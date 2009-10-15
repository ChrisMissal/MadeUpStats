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
                    .AddWithName("home-index", routes);
            MvcRoute.MappUrl("information")
                    .ToDefaultAction<HomeController>(x => x.Information())
                    .AddWithName("information", routes);
            MvcRoute.MappUrl("about")
                    .ToDefaultAction<HomeController>(x => x.About())
                    .AddWithName("about", routes);

            MvcRoute.MappUrl("tags/{tagName}")
                    .WithConstraints(new { tagName = "^[A-Za-z0-9\\-\\.]+$" })
                    .ToDefaultAction<TagsController>(x => x.Index(null))
                    .AddWithName("tags-tagName", routes);
            MvcRoute.MappUrl("all-tags")
                    .ToDefaultAction<TagsController>(x => x.Index())
                    .AddWithName("all-tags", routes);

            MvcRoute.MappUrl("create-stat")
                    .ToDefaultAction<StatController>(x => x.Create())
                    .AddWithName("create-stat", routes);
            MvcRoute.MappUrl("{id}")
                    .WithConstraints(new { id = "^[0-9]+$" })
                    .ToDefaultAction<StatController>(x => x.Index(0))
                    .AddWithName("stat-id", routes);

            // Default/fallback route
            routes.MapRoute("Default", "{controller}/{action}/{id}",
                            new { controller = "Home", action = "Index", id = "" });
        }
    }
}