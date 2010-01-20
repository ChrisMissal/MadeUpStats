using System;
using System.Linq;
using System.Web.Mvc;
using MvcContrib;

namespace MadeUpStats.Web
{
    public class RebindTempDataAttribute : ActionFilterAttribute
    {
        private readonly Type[] types;

        public RebindTempDataAttribute(Type type) : this(new[] { type })
        {
        }

        public RebindTempDataAttribute(Type[] types)
        {
            this.types = types;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller;
            
            foreach (var type in types.Where(type => controller.TempData.Contains(type)))
            {
                var defaultObject = !type.IsArray ? Activator.CreateInstance(type) : Array.CreateInstance(type.GetElementType(), 0);
                controller.ViewData.Model = controller.TempData.GetOrDefault(type.FullName, defaultObject);
            }
        }
    }
}