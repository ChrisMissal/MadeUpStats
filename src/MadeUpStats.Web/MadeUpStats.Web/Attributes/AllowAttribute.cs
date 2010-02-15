using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using MadeUpStats.Services;

namespace MadeUpStats.Web.Attributes
{
    public class AllowAttribute : ActionFilterAttribute
    {
        private readonly IUserAccessService userAccessService = Bootstrapper.Container.GetInstance<IUserAccessService>();
        protected readonly IEnumerable<string> allowedRoles;

        protected AllowAttribute(IEnumerable<string> allowedRoles)
        {
            this.allowedRoles = allowedRoles;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (userAccessService.CurrentUserNeedsToLogin())
                RedirectToLogin(filterContext);

            if (userAccessService.CurrentUserRolesMatch(allowedRoles))
                return;

            RedirectToLogin(filterContext);
        }

        private static void RedirectToLogin(ControllerContext controllerContext)
        {
            controllerContext.HttpContext.Response.Redirect(FormsAuthentication.LoginUrl);
        }
    }
}
