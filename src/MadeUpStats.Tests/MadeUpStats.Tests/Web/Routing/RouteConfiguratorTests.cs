using System.Text.RegularExpressions;
using MadeUpStats.Web.Controllers;
using MadeUpStats.Web.Routing;
using MvcContrib.TestHelper;
using Xunit;

namespace MadeUpStats.Tests.Web.Routing
{
    public class RouteConfiguratorTests
    {
        [Fact]
        public void Routes_regex_for_tags_matches_expectations()
        {
            var regex = new Regex("^[A-Za-z0-9\\-\\.]+$");
            Assert.True(regex.IsMatch("tag"));
            Assert.True(regex.IsMatch("catch22"));
            Assert.True(regex.IsMatch("abc-d"));
            Assert.True(regex.IsMatch("asp.net-mvc"));
            Assert.False(regex.IsMatch("a b"));
            Assert.False(regex.IsMatch("c|"));
            Assert.False(regex.IsMatch("d+"));
            Assert.False(regex.IsMatch("e="));
        }

        [Fact]
        public void Routes_map_to_the_correct_Controllers()
        {
            new RouteConfigurator().RegisterRoutes();
            "~/".ShouldMapTo<HomeController>(x => x.Index());
            "~/information".ShouldMapTo<HomeController>(x => x.Information());
            "~/about".ShouldMapTo<HomeController>(x => x.About());
            "~/create-stat".ShouldMapTo<StatController>(x => x.Create());
            "~/12345".ShouldMapTo<StatController>(x => x.Index(12345));
            "~/all-tags".ShouldMapTo<TagsController>(x => x.AllTags());
            "~/tags/people".ShouldMapTo<TagsController>(x => x.Index("people"));
        }
    }
}