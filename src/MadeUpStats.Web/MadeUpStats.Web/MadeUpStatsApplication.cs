using System.Web.Mvc;
using MadeUpStats.Web.Routing;
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
                    .AddAssembly("MadeUpStats.Web")
                    .AddNamespace("Microsoft.Web.Mvc")
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