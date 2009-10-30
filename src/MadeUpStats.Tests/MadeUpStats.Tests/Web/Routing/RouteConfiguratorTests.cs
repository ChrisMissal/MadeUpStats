using MadeUpStats.Framework;
using MadeUpStats.Web.Controllers;
using MadeUpStats.Web.Routing;
using MvcContrib.TestHelper;
using Xunit;

namespace MadeUpStats.Tests.Web.Routing
{
    public class RouteConfiguratorTests
    {
        [Fact]
        public void Routes_map_to_the_correct_Controllers()
        {
            new RouteConfigurator().RegisterRoutes();
            "~/".ShouldMapTo<HomeController>(x => x.Index());
            "~/information".ShouldMapTo<HomeController>(x => x.Information());
            "~/about".ShouldMapTo<HomeController>(x => x.About());
            "~/create-stat".ShouldMapTo<StatController>(x => x.Create());
            "~/stat/some-stat-key".ShouldMapTo<StatController>(x => x.Index("some-stat-key"));
            "~/all-tags".ShouldMapTo<TagsController>(x => x.AllTags());
            "~/tags/people".ShouldMapTo<TagsController>(x => x.Index("people"));
        }
    }
}