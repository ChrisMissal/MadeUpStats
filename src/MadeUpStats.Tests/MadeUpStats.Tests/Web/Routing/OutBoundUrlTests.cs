using System;
using MadeUpStats.Web.Controllers;
using MadeUpStats.Web.Routing;
using MvcContrib.TestHelper;
using Xunit;

namespace MadeUpStats.Tests.Web.Routing
{
    public class OutBoundUrlTests
    {
        [Fact]
        public void Routes_map_to_correct_Urls()
        {
            new RouteConfigurator().RegisterRoutes();

            OutBoundUrl.Of<HomeController>(x => x.Index()).ShouldMapToUrl("/");
            OutBoundUrl.Of<HomeController>(x => x.About()).ShouldMapToUrl("/about");
            OutBoundUrl.Of<HomeController>(x => x.Information()).ShouldMapToUrl("/information");

            OutBoundUrl.Of<StatController>(x => x.Create()).ShouldMapToUrl("/create-stat");
            OutBoundUrl.Of<StatController>(x => x.Index("key-abc")).ShouldMapToUrl("/stat/key-abc");

            OutBoundUrl.Of<TagsController>(x => x.AllTags()).ShouldMapToUrl("/all-tags");
            OutBoundUrl.Of<TagsController>(x => x.Index("what")).ShouldMapToUrl("/tags/what");
        }
    }
}