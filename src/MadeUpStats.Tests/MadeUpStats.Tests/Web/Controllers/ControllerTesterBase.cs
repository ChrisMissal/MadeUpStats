using MadeUpStats.Tests.Data;
using MadeUpStats.Web;
using MadeUpStats.Web.Controllers;
using Moq;

namespace MadeUpStats.Tests.Web.Controllers
{
    public abstract class ControllerTesterBase<T> : StatHelper where T : BaseController
    {
        protected Mock<IUserInterfaceManager> userInterfaceManager;

        public abstract T GetController();
    }
}