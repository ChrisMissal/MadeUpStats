using MadeUpStats.Domain;

namespace MadeUpStats.Data
{
    public interface IUserRepository
    {
        IUser GetUser(string username);
    }
}