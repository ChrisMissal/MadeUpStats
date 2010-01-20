using System.Web;
using MadeUpStats.Data;
using MadeUpStats.Domain;
using MadeUpStats.Framework;

namespace MadeUpStats.Services
{
    public class HttpUserSession : IUserSession
    {
        private readonly IUserRepository userRepository;

        private const string IUSER = "IUSER";

        public HttpUserSession(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public bool TrySignIn(string userName, string password)
        {
            var user = userRepository.GetUser(userName);

            return user.Exists();
        }

        public IUser GetUser()
        {
            return HttpContext.Current.Session[IUSER] as IUser;
        }
    }
}