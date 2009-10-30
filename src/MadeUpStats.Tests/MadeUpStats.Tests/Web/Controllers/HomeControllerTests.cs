using System.Web.Mvc;
using MadeUpStats.Services;
using MadeUpStats.Web;
using MadeUpStats.Web.Controllers;
using MadeUpStats.Web.Models;
using MadeUpStats.Web.Services;
using Moq;
using Xunit;

namespace MadeUpStats.Tests.Web.Controllers
{
    public class HomeControllerTests : ControllerTesterBase<HomeController>
    {
        protected Mock<IStatService> statService;
        protected Mock<IMapper> mapper;

        [Fact]
        public void HomeController_should_return_a_HomeDisplay_for_Index()
        {
            var controller = GetController();
            var view = controller.Index() as ViewResult;
            view.ViewData.Model.ShouldBeOfType<HomeDisplay>();
        }

        [Fact]
        public void HomeController_should_call_StatService_GetMostRecentStats_for_Index()
        {
            var controller = GetController();
            controller.Index();
            statService.Verify(x => x.GetMostRecentStats(It.IsAny<int>()), Times.Once());
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