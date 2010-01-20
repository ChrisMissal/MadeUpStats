using System.Web;
using MadeUpStats.Data;
using MadeUpStats.Domain;

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
            userRepository.GetUser(userName);

            return false;
        }

        public IUser GetUser()
        {
            return HttpContext.Current.Session[IUSER] as IUser;
        }
    }
}