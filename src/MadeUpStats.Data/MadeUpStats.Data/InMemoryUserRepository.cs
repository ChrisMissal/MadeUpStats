using MadeUpStats.Domain;

namespace MadeUpStats.Data
{
    public class InMemoryUserRepository : IUserRepository
    {
        public IUser GetUser(string username)
        {
            var user = new User(username);
            return user.WithRole("Admin");
        }
    }
}