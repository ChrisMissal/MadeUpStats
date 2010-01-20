using System;
using System.Web.Mvc;
using MadeUpStats.Framework;
using MadeUpStats.Services;
using MadeUpStats.Web.Models;

namespace MadeUpStats.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserSession userSession;

        public UserController(IUserInterfaceManager userInterfaceManager, IUserSession userSession) : base(userInterfaceManager)
        {
            this.userSession = userSession;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Login()
        {
            return View("Login");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Login(LoginInput loginInput)
        {
            try
            {
                Validate.NotNullOrEmpty(loginInput.UserName, "UserName");
                Validate.NotNullOrEmpty(loginInput.Password, "Password");

                userSession.TrySignIn(loginInput.UserName, loginInput.Password);

                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                userInterfaceManager.AddMessage(ex.Message);
            }

            return View(loginInput);
        }
    }
}