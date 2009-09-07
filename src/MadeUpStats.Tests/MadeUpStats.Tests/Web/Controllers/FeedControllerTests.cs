using MadeUpStats.Web;
using MadeUpStats.Web.Controllers;
using MadeUpStats.Web.Services;
using Moq;
using Xunit;

namespace MadeUpStats.Tests.Web.Controllers
{
    public class FeedControllerTests : ControllerTesterBase<FeedController>
    {
        protected Mock<IFeedService> feedService;

        public override FeedController GetController()
        {
            feedService = new Mock<IFeedService>();
            userInterfaceManager = new Mock<IUserInterfaceManager>();

            return new FeedController(feedService.Object, userInterfaceManager.Object);
        }

        [Fact]
        public void FeedController_should_call_FeedService_GetFeed_for_Index()
        {
            var controller = GetController();

            controller.Index();

            feedService.Verify(x => x.CreateFeed());
        }
    }
}