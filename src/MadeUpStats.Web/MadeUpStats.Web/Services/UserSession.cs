using System.Collections.Generic;
using MadeUpStats.Data;
using MadeUpStats.Domain;
using MadeUpStats.Framework;
using MadeUpStats.Services;

namespace MadeUpStats.Web.Services
{
    public class UserSession : IUserSession
    {
        private readonly IHttpContextProvider httpContextProvider;
        private readonly IUserRepository userRepository;

        private const string IUSER = "IUSER";
        private const string MESSAGES = "messages";

        public UserSession(IHttpContextProvider httpContextProvider, IUserRepository userRepository)
        {
            this.httpContextProvider = httpContextProvider;
            this.userRepository = userRepository;
        }

        public bool TrySignIn(string userName, string password)
        {
            var user = userRepository.GetUser(userName);

            httpContextProvider.GetHttpSession()[IUSER] = user;

            return user.Exists();
        }

        public IUser GetUser()
        {
            return httpContextProvider.GetHttpSession()[IUSER] as IUser;
        }

        public Queue<string> GetMessages()
        {
            var session = httpContextProvider.GetHttpSession();

            return (session[MESSAGES] ?? (session[MESSAGES] = new Queue<string>()) as Queue<string>) as Queue<string>;
        }
    }
}