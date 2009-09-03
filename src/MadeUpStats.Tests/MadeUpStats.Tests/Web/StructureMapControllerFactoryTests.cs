using MadeUpStats.Web;
using MadeUpStats.Web.Controllers;
using Xunit;

namespace MadeUpStats.Tests.Web
{
    public class StructureMapControllerFactoryTests
    {
        [Fact]
        public void StructureMapControllerFactory_should_return_HomeController_for_Home()
        {
            var controller = new StructureMapControllerFactory().CreateController(null, "Home");
            Assert.IsType(typeof (HomeController), controller);
        }

        [Fact]
        public void StructureMapControllerFactory_should_return_StatController_for_Stat()
        {
            var controller = new StructureMapControllerFactory().CreateController(null, "Stat");
            Assert.IsType(typeof(StatController), controller);
        }
    }
}