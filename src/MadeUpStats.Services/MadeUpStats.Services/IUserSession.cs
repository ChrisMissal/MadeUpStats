using System.Collections.Generic;
using MadeUpStats.Domain;

namespace MadeUpStats.Services
{
    public interface IUserSession
    {
        bool TrySignIn(string userName, string password);

        IUser GetUser();

        Queue<string> GetMessages();
    }
}