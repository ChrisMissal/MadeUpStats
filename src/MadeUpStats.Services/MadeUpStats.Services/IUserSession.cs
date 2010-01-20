using MadeUpStats.Domain;

namespace MadeUpStats.Services
{
    public interface IUserSession
    {
        IUser GetUser();
    }
}