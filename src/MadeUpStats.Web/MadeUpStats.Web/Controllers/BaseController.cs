using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using MadeUpStats.Web.Extensions;
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

        public virtual ViewResult View(DisplayBase model)
        {
            return View(model.GetViewName(), model);
        }

        public RedirectToRouteResult RedirectToAction<TController>(Expression<Func<TController, object>> actionExpression)
        {
            return RedirectToAction(actionExpression, null);
        }

        public RedirectToRouteResult RedirectToAction<TController>(Expression<Func<TController, object>> actionExpression, object routeValues)
        {
            var controllerName = typeof(TController).GetControllerName();
            var actionName = actionExpression.GetActionName();

            return RedirectToAction(actionName, controllerName, new RouteValueDictionary(routeValues));
        }
    }
}