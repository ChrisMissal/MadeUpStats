using MadeUpStats.Web.Controllers;
using MadeUpStats.Web.Routing;
using MvcContrib.TestHelper;
using Xunit;

namespace MadeUpStats.Tests.Web.Routing
{
    public class RouteConfiguratorTests
    {
        [Fact]
        public void StatsController_should_map_to_domain_slash_id()
        {
            new RouteConfigurator().RegisterRoutes();
            //"~/Stat/Create".ShouldMapTo<StatController>(x => x.Create());
            //"~/Stat/12345".ShouldMapTo<StatController>(x => x.Index(12345));
            //"~/Tag/nintendo".ShouldMapTo<TagController>(x => x.Index("nintendo"));
        }
    }
}