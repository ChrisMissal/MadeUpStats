using MadeUpStats.Domain;

namespace MadeUpStats.Data
{
    public class InMemoryUserRepository : IUserRepository
    {
        public IUser GetUser(string username)
        {
            return new User(username);
        }
    }
}