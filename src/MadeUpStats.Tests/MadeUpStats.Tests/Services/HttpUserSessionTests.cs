using System.Web;
using MadeUpStats.Data;
using MadeUpStats.Domain;
using MadeUpStats.Web;
using MadeUpStats.Web.Services;
using Moq;
using Xunit;

namespace MadeUpStats.Tests.Services
{
    public class HttpUserSessionTests
    {
        private Mock<IUserRepository> userRepository;
        private Mock<IHttpContextProvider> httpContextProvider;

        [Fact]
        public void TrySignIn_should_call_Repository_with_UserName()
        {
            var userSession = GetUserSession();
            var session = new Mock<HttpSessionStateBase>();
            httpContextProvider.Setup(x => x.GetHttpSession()).Returns(session.Object);

            userSession.TrySignIn("userName", "password");

            userRepository.Verify(x => x.GetUser("userName"));
        }

        [Fact]
        public void GetUser_should_be_gotten_from_IHttpContextProvider()
        {
            var userSession = GetUserSession();
            var session = new Mock<HttpSessionStateBase>();
            httpContextProvider.Setup(x => x.GetHttpSession()).Returns(session.Object);

            userSession.GetUser();

            session.Verify(x => x["IUSER"]);
        }

        [Fact]
        public void TrySignIn_should_set_IUser_to_HttpContextProvider_Session()
        {
            var userSession = GetUserSession();
            var session = new Mock<HttpSessionStateBase>();
            httpContextProvider.Setup(x => x.GetHttpSession()).Returns(session.Object);

            userSession.TrySignIn("userName", "password");

            session.VerifySet(x => x["IUSER"] = It.IsAny<IUser>());
        }

        private HttpUserSession GetUserSession()
        {
            userRepository = new Mock<IUserRepository>();
            httpContextProvider = new Mock<IHttpContextProvider>();

            return new HttpUserSession(httpContextProvider.Object, userRepository.Object);
        }
    }
}