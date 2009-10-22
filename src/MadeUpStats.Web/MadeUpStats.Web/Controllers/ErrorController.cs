using System.Web.Mvc;
using MadeUpStats.Web.Models;

namespace MadeUpStats.Web.Controllers
{
    public class ErrorController : BaseController
    {
        public ErrorController(IUserInterfaceManager userInterfaceManager) : base(userInterfaceManager)
        {
        }

        public ActionResult Error()
        {
            return View(new ErrorIndexDisplay());
        }
    }
}