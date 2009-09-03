using System.Collections.Generic;

namespace MadeUpStats.Web
{
    public class UserInterfaceManager : IUserInterfaceManager
    {
        private readonly Stack<string> errorMessages = new Stack<string>();
        private readonly IHttpContextProvider httpContextProvider;

        public UserInterfaceManager(IHttpContextProvider httpContextProvider)
        {
            this.httpContextProvider = httpContextProvider;
        }

        public void AddMessage(string message)
        {
            var stack = GetErrorMessageStack();
            stack.Push(message);
        }

        private Stack<string> GetErrorMessageStack()
        {
            var errorMessageStack = new Stack<string>();
            var stack = (Stack<string>)httpContextProvider.GetHttpSession()["errormessages"] ?? errorMessageStack;
            httpContextProvider.GetHttpSession()["errormessages"] = stack;
            return errorMessages;
        }

        public IEnumerable<string> GetMessages()
        {
            var messages = new List<string>();
            var stack = GetErrorMessageStack();
            while (stack.Count > 0)
                messages.Add(stack.Pop());
                /*yield return stack.Pop();*/
            return messages;
        }
    }
}