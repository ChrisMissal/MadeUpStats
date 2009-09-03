using MadeUpStats.Web.Routing;
using Xunit;

namespace MadeUpStats.Tests.Web
{
    public class RoutingTests
    {
        [Fact]
        public void HomeController_routes_should_resolve_correctly()
        {
            new RouteConfigurator().RegisterRoutes();
            //"~/".ShouldMapTo<HomeController>(x => x.Index());
        }

        [Fact]
        public void StatController_routes_should_resolve_correctly()
        {
            new RouteConfigurator().RegisterRoutes();
            //"~/Stat/1234".ShouldMapTo<StatController>(x => x.Index(1234));
            //"~/Stat/Create".ShouldMapTo<StatController>(x => x.Create());
        }
    }
}