using MadeUpStats.Domain;
using MadeUpStats.Framework;

namespace MadeUpStats.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUserSession userSession;

        public AuthorService(IUserSession userSession)
        {
            this.userSession = userSession;
        }

        public Author GetLoggedInAuthor()
        {
            var user = userSession.GetUser();

            if (user.DoesNotExist())
                return null;

            Validate.NotNullOrEmpty(user.UserName, "UserName");

            return new Author(user.UserName);
        }
    }
}