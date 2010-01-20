using MvcContrib;
using System.Web.Mvc;

namespace MadeUpStats.Web
{
    public class ModelStateRebindAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller;

            if (!controller.TempData.Contains<ModelStateDictionary>())
                return;

            var modelState = controller.TempData.Get<ModelStateDictionary>();

            foreach (var pair in modelState)
            {
                controller.ViewData.ModelState.Add(pair.Key, pair.Value);
            }
        }
    }
}