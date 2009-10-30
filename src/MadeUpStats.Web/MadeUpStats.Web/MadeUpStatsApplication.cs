using System.Web.Mvc;
using MadeUpStats.Web.Models;
using MadeUpStats.Web.Routing;
using MadeUpStats.Web.Views;
using Spark;
using Spark.Web.Mvc;

namespace MadeUpStats.Web
{
    public class MadeUpStatsConfiguration : IMvcConfiguration
    {
        private readonly IRouteConfigurator routeConfigurator;
        private readonly IControllerFactory controllerFactory;

        public MadeUpStatsConfiguration(IRouteConfigurator routeConfigurator, IControllerFactory controllerFactory)
        {
            this.routeConfigurator = routeConfigurator;
            this.controllerFactory = controllerFactory;
        }

        public IRouteConfigurator GetRouteConfigurator()
        {
            return routeConfigurator;
        }

        public IViewEngine GetViewEngine()
        {
            var settings = new SparkSettings()
                    .SetDebug(true)
                    .SetPageBaseType(typeof(MadeUpStatsViewPage))
                    .AddAssembly(GetType().Assembly)
                    .AddNamespace(typeof(HomeDisplay).Assembly.FullName)
                    .AddNamespace("Microsoft.Web.Mvc")
                    .AddNamespace("MvcContrib")
                    .AddNamespace("System")
                    .AddNamespace("System.Collections.Generic")
                    .AddNamespace("System.Linq")
                    .AddNamespace("System.Web.Mvc");

            return new SparkViewFactory(settings);
        }

        public IControllerFactory GetControllerFactory()
        {
            return controllerFactory;
        }
    }
}