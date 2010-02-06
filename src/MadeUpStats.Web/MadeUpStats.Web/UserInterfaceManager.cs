using System.Collections.Generic;
using MadeUpStats.Services;

namespace MadeUpStats.Web
{
    public class UserInterfaceManager : IUserInterfaceManager
    {
        private readonly IUserSession userSession;

        public UserInterfaceManager(IUserSession userSession)
        {
            this.userSession = userSession;
        }

        public void AddMessage(string message)
        {
            var queue = GetErrorMessageQueue();
            queue.Enqueue(message);
        }

        private Queue<string> GetErrorMessageQueue()
        {
            return userSession.GetMessages();
        }

        public IEnumerable<string> GetMessages()
        {
            var messages = new List<string>();
            var queue = GetErrorMessageQueue();
            while (queue.Count > 0)
                messages.Add(queue.Dequeue());
                
            return messages;
        }
    }
}