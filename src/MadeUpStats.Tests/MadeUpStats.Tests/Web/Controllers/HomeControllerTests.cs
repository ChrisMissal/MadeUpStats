using System.Web.Mvc;
using MadeUpStats.Services;
using MadeUpStats.Web;
using MadeUpStats.Web.Controllers;
using MadeUpStats.Web.Models;
using MadeUpStats.Web.Services;
using Moq;
using MvcContrib.TestHelper;
using Xunit;

namespace MadeUpStats.Tests.Web.Controllers
{
    public class HomeControllerTests : ControllerTesterBase<HomeController>
    {
        protected Mock<IStatService> statService;
        protected Mock<IMapper> mapper;

        [Fact]
        public void Index_should_return_a_HomeDisplay()
        {
            var controller = GetController();
            var view = controller.Index() as ViewResult;
            view.AssertViewRendered().WithViewData<HomeDisplay>();
        }

        [Fact]
        public void Index_should_call_StatService_GetMostRecentStats()
        {
            var controller = GetController();
            controller.Index();
            statService.Verify(x => x.GetMostRecentStats(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void Information_should_return_a_HomeInformationDisplay()
        {
            var controller = GetController();
            var view = controller.Information() as ViewResult;
            view.AssertViewRendered().WithViewData<InformationDisplay>();
        }

        [Fact]
        public void Information_should_call_StatService_for_number_of_Stats()
        {
            GetController().Information();
            statService.Verify(x => x.GetNumberOfStats());
        }

        [Fact]
        public void Information_should_return_a_HomeInformationDisplay_with_number_of_stats()
        {
            var controller = GetController();
            statService.Setup(x => x.GetNumberOfStats()).Returns(123);
            var result = controller.Information() as ViewResult;
            var display = result.ViewData.Model as InformationDisplay;
            display.StatCount.ShouldEqual(123);
        }

        public override HomeController GetController()
        {
            statService = new Mock<IStatService>();
            mapper = new Mock<IMapper>();
            userInterfaceManager = new Mock<IUserInterfaceManager>();

            return new HomeController(statService.Object, mapper.Object, userInterfaceManager.Object);
        }
    }
}