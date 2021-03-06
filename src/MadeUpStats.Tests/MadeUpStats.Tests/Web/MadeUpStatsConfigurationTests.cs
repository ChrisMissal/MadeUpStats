using System.Web.Mvc;
using MadeUpStats.Web;
using MadeUpStats.Web.Routing;
using Moq;
using Xunit;

namespace MadeUpStats.Tests.Web
{
    public class MadeUpStatsConfigurationTests
    {
        [Fact]
        public void MadeUpStatsConfiguration_should_return_supplied_RouteConfigurator()
        {
            var routeConfigurator = new Mock<IRouteConfigurator>();

            var configuration = new MvcConfiguration(routeConfigurator.Object, null);

            configuration.GetRouteConfigurator().ShouldBe(routeConfigurator.Object);
        }

        [Fact]
        public void MadeUpStatsConfiguration_should_return_supplied_ControllerFactory()
        {
            var controllerFactory = new Mock<IControllerFactory>();

            var configuration = new MvcConfiguration(null, controllerFactory.Object);

            configuration.GetControllerFactory().ShouldBe(controllerFactory.Object);
        }

        [Fact]
        public void MadeUpStatsConfiguration_should_return_a_non_null_IViewEngine()
        {
            new MvcConfiguration(null, null).GetViewEngine().ShouldNotBeNull();
        }
    }
}