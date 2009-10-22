using MadeUpStats.Tests.Fakes;
using Moq;
using Xunit;

namespace MadeUpStats.Tests.Web.Controllers
{
    public class BaseControllerTests
    {
        [Fact]
        public void BaseController_should_return_a_View_name_by_ViewModel_type_name_minus_ViewModel()
        {
            var fakeModel = new FakeDisplay();
            var baseController = new FakeBaseController();

            var view = baseController.View(fakeModel);

            view.ViewName.ShouldEqual("Fake");
        }

        [Fact]
        public void BaseController_should_call_AddMessage_on_IUserInterfaceManager_for_AddMessage()
        {
            const string message = "fake base controller";
            var baseController = new FakeBaseController();

            baseController.AddMessage(message);

            baseController.MockUserInterfaceManager.Verify(x => x.AddMessage(message), Times.Once());
        }
    }
}