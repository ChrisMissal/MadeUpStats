using System.Linq;
using System.Web;
using MadeUpStats.Web;
using Moq;
using Xunit;

namespace MadeUpStats.Tests.Web
{
    public class UserInterfaceManagerTests
    {
        [Fact]
        public void UserInterfaceManager_can_add_ErrorMessages_and_retrieve_them()
        {
            const string errorMessage1 = "how dare you!";
            const string errorMessage2 = "STOP IT!";
            var httpContextProvider = new Mock<IHttpContextProvider>();
            httpContextProvider.Setup(x => x.GetHttpSession()).Returns(new Mock<HttpSessionStateBase>().Object);

            var provider = new UserInterfaceManager(httpContextProvider.Object);
            provider.AddMessage(errorMessage1);
            provider.AddMessage(errorMessage2);

            var messages = provider.GetMessages();

            messages.Count().ShouldEqual(2);
        }
    }
}