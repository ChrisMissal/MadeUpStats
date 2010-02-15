using System;
using System.Collections.Generic;
using MadeUpStats.Framework;

namespace MadeUpStats.Domain
{
    public class User : Entity, IUser, IKeyable<string>
    {
        private readonly string userName;
        private readonly List<string> roles = new List<string>();

        public User(string userName)
        {
            this.userName = userName;
        }

        public string UserName
        {
            get { return userName; }
        }

        public IEnumerable<string> Roles
        {
            get { return roles; }
        }

        public string Key
        {
            get { return userName; }
        }

        public User WithRole(string role)
        {
            if(roles.Contains(role))
                throw new InvalidOperationException("User is already in role '{0}'.".FormatWith(role));

            roles.Add(role);
            return this;
        }
    }
}