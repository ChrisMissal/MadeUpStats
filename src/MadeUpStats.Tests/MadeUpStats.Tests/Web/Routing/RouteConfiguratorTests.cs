using MadeUpStats.Web.Controllers;
using MadeUpStats.Web.Routing;
using MvcContrib.TestHelper;
using Xunit;

namespace MadeUpStats.Tests.Web.Routing
{
    public class RouteConfiguratorTests
    {
        [Fact]
        public void Routes_map_to_the_Controllers_I_tell_them_to()
        {
            new RouteConfigurator().RegisterRoutes();
            "~/".ShouldMapTo<HomeController>(x => x.Index());
            "~/Information".ShouldMapTo<HomeController>(x => x.Information());
            "~/About".ShouldMapTo<HomeController>(x => x.About());
            "~/Stat/Create".ShouldMapTo<StatController>(x => x.Create());
            "~/Stat/12345".ShouldMapTo<StatController>(x => x.Index(12345));
            "~/Tags".ShouldMapTo<TagsController>(x => x.Index());
            "~/Tags/nintendo".ShouldMapTo<TagsController>(x => x.Index("nintendo"));
        }
    }
}