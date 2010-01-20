using System.Web;
using MadeUpStats.Domain;

namespace MadeUpStats.Services
{
    public class HttpUserSession : IUserSession
    {
        private const string IUSER = "IUSER";

        public IUser GetUser()
        {
            return HttpContext.Current.Session[IUSER] as IUser;
        }
    }
}