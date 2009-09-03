using System.Web.Mvc;

namespace MadeUpStats.Web.Controllers
{
    public class MessagesController : BaseController
    {
        public MessagesController(IUserInterfaceManager userInterfaceManager) : base(userInterfaceManager)
        {
        }

        public ActionResult GetMessages()
        {
            return PartialView("MessageList", userInterfaceManager.GetMessages());
        }
    }
}