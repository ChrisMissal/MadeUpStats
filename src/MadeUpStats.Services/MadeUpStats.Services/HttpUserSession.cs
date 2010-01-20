using System;
using System.Web;
using MadeUpStats.Domain;

namespace MadeUpStats.Services
{
    public class HttpUserSession : IUserSession
    {
        private const string IUSER = "IUSER";

        public bool TrySignIn(string userName, string password)
        {
            return false;
        }

        public IUser GetUser()
        {
            return HttpContext.Current.Session[IUSER] as IUser;
        }
    }
}