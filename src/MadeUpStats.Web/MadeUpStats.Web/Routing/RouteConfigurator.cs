using System.Web.Mvc;
using System.Web.Routing;
using MadeUpStats.Web.Controllers;
using MvcContrib.Routing;

namespace MadeUpStats.Web.Routing
{
    public class RouteConfigurator : IRouteConfigurator
    {
        private readonly RouteCollection routes;
        private const string KEY_REGEX_PATTERN = "^[A-Za-z0-9\\-\\.]+$";

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
                    .WithConstraints(new { tagName = KEY_REGEX_PATTERN })
                    .ToDefaultAction<TagsController>(x => x.Index(null))
                    .AddWithName("tags-tagName", routes);
            MvcRoute.MappUrl("all-tags")
                    .ToDefaultAction<TagsController>(x => x.AllTags())
                    .AddWithName("all-tags", routes);

            MvcRoute.MappUrl("create-stat")
                    .ToDefaultAction<StatController>(x => x.Create())
                    .AddWithName("create-stat", routes);
            MvcRoute.MappUrl("stat/{key}")
                    .WithConstraints(new { key = KEY_REGEX_PATTERN })
                    .ToDefaultAction<StatController>(x => x.Index(""))
                    .AddWithName("stat-key", routes);

            // Default/fallback route
            routes.MapRoute("Default", "{controller}/{action}/{id}",
                            new { controller = "Home", action = "Index", id = "" });
        }
    }
}