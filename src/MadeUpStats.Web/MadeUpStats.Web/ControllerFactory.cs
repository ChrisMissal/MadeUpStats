using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace MadeUpStats.Web
{
    public class ControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            try
            {
                return Bootstrapper.Container.GetInstance<IController>(controllerName.ToLowerInvariant());
            }
            catch (Exception)
            {
                return base.CreateController(requestContext, controllerName);
            }
        }
    }
}