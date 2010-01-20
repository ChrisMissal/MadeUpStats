using MadeUpStats.Framework;

namespace MadeUpStats.Domain
{
    public class User : Entity, IUser, IKeyable<string>
    {
        private readonly string userName;

        public User(string userName)
        {
            this.userName = userName;
        }

        public string UserName
        {
            get { return userName; }
        }

        public string Key
        {
            get { return userName; }
        }
    }
}