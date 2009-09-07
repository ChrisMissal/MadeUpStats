using System.Web.Mvc;
using MadeUpStats.Services;
using MadeUpStats.Web;
using MadeUpStats.Web.Controllers;
using MadeUpStats.Web.Models.Home;
using Moq;
using Xunit;

namespace MadeUpStats.Tests.Web.Controllers
{
    public class HomeControllerTests : ControllerTesterBase<HomeController>
    {
        protected Mock<IStatService> statService;

        [Fact]
        public void HomeController_should_return_a_HomeIndexViewModel_for_Index()
        {
            var controller = GetController();
            var view = controller.Index() as ViewResult;
            view.ViewData.Model.ShouldBeOfType<IndexViewModel>();
        }

        [Fact]
        public void HomeController_should_call_StatService_GetMostRecentStats_for_Index()
        {
            var controller = GetController();
            controller.Index();
            statService.Verify(x => x.GetMostRecentStats(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void HomeController_should_return_an_AboutViewModel_for_About()
        {
            var controller = GetController();
            var view = controller.About() as ViewResult;
            view.ViewData.Model.ShouldBeOfType<AboutViewModel>();
        }

        public override HomeController GetController()
        {
            statService = new Mock<IStatService>();
            userInterfaceManager = new Mock<IUserInterfaceManager>();

            return new HomeController(statService.Object, userInterfaceManager.Object);
        }
    }
}