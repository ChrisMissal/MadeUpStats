using System.Web.Mvc;
using MadeUpStats.Services;
using MadeUpStats.Web;
using MadeUpStats.Web.Controllers;
using MadeUpStats.Web.Models;
using Moq;
using MvcContrib.TestHelper;
using Xunit;

namespace MadeUpStats.Tests.Web.Controllers
{
    public class UserControllerTests
    {
        private Mock<IUserInterfaceManager> userInterfaceManager;
        private Mock<IUserSession> userSession;

        [Fact]
        public void Login_POST_should_add_message_if_UserName_is_null()
        {
            var loginInput = new LoginInput { UserName = null };
            var controller = GetController();

            controller.Login(loginInput);

            userInterfaceManager.Verify(x => x.AddMessage(It.IsAny<string>()));
        }

        [Fact]
        public void Login_POST_should_add_message_if_UserName_is_empty_string()
        {
            var loginInput = new LoginInput { UserName = "" };
            var controller = GetController();

            controller.Login(loginInput);

            userInterfaceManager.Verify(x => x.AddMessage(It.IsAny<string>()));
        }

        [Fact]
        public void Login_POST_should_add_message_if_Password_is_null()
        {
            var loginInput = new LoginInput { Password = null };
            var controller = GetController();

            controller.Login(loginInput);

            userInterfaceManager.Verify(x => x.AddMessage(It.IsAny<string>()));
        }

        [Fact]
        public void Login_POST_should_add_message_if_Password_is_empty_string()
        {
            var loginInput = new LoginInput { Password = "" };
            var controller = GetController();

            controller.Login(loginInput);

            userInterfaceManager.Verify(x => x.AddMessage(It.IsAny<string>()));
        }

        [Fact]
        public void Login_POST_should_TrySignIn_if_Password_and_UserName_exist()
        {
            var loginInput = new LoginInput { Password = "p", UserName = "u" };
            var controller = GetController();

            controller.Login(loginInput);

            userSession.Verify(x => x.TrySignIn("u", "p"));
        }

        [Fact]
        public void Login_that_is_successful_should_go_to_home_page()
        {
            var loginInput = new LoginInput {Password = "p", UserName = "u"};
            var controller = GetController();

            var result = controller.Login(loginInput) as RedirectToRouteResult;

            result.ToAction<HomeController>(x => x.Index());
        }

        [Fact]
        public void Login_GET_should_return_a_LoginInput_as_the_Model()
        {
            var controller = GetController();
            var result = controller.Login() as ViewResult;
            result.AssertViewRendered().WithViewData<LoginInput>();
        }

        private UserController GetController()
        {
            userSession = new Mock<IUserSession>();
            userInterfaceManager = new Mock<IUserInterfaceManager>();

            return new UserController(userInterfaceManager.Object, userSession.Object);
        }
    }
}