using MadeUpStats.Web;
using MadeUpStats.Web.Controllers;
using Moq;
using Xunit;

namespace MadeUpStats.Tests.Web.Controllers
{
    public class MessagesControllerTests : ControllerTesterBase<MessagesController>
    {
        [Fact]
        public void MessagesController_should_call_IUserInterfaceManager_GetMessages()
        {
            GetController().GetMessages();

            userInterfaceManager.Verify(x => x.GetMessages());
        }

        public override MessagesController GetController()
        {
            userInterfaceManager = new Mock<IUserInterfaceManager>();

            return new MessagesController(userInterfaceManager.Object);
        }
    }
}