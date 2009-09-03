using System.Web.Mvc;
using MadeUpStats.Web.Models;

namespace MadeUpStats.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IUserInterfaceManager userInterfaceManager;

        protected BaseController(IUserInterfaceManager userInterfaceManager)
        {
            this.userInterfaceManager = userInterfaceManager;
        }

        public virtual void AddMessage(string message)
        {
            userInterfaceManager.AddMessage(message);
        }

        public virtual ViewResult View(ViewModel model)
        {
            return View(model.GetViewName(), model);
        }
    }
}