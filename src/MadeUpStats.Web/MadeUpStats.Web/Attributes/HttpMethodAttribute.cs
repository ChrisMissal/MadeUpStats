using System;
using System.Reflection;
using System.Web.Mvc;
using MadeUpStats.Framework;

namespace MadeUpStats.Web.Attributes
{
    public abstract class HttpMethodAttribute : ActionMethodSelectorAttribute
    {
        protected string method;

        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            Validate.NotNull(controllerContext, "controllerContext");

            var httpMethod = controllerContext.HttpContext.Request.HttpMethod;

            return httpMethod.Equals(method, StringComparison.OrdinalIgnoreCase);
        }
    }
}