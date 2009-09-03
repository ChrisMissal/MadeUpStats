using System.Collections.Generic;

namespace MadeUpStats.Web
{
    public interface IUserInterfaceManager
    {
        void AddMessage(string message);

        IEnumerable<string> GetMessages();
    }
}