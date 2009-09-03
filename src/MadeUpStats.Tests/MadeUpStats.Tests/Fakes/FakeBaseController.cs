using MadeUpStats.Web;
using MadeUpStats.Web.Controllers;
using MadeUpStats.Web.Models;
using Moq;

namespace MadeUpStats.Tests.Fakes
{
    public class FakeBaseController : BaseController
    {
        private readonly Mock<IUserInterfaceManager> mockUserInterfaceManager;

        private FakeBaseController(Mock<IUserInterfaceManager> mockUserInterfaceManager) : base(mockUserInterfaceManager.Object)
        {
            this.mockUserInterfaceManager = mockUserInterfaceManager;
        }

        public FakeBaseController() : this(new Mock<IUserInterfaceManager>())
        {
        }

        public Mock<IUserInterfaceManager> MockUserInterfaceManager
        {
            get { return mockUserInterfaceManager; }
        }
    }
}