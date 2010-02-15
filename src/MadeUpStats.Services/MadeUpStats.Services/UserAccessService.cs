using System.Collections.Generic;
using System.Linq;
using MadeUpStats.Domain;
using MadeUpStats.Framework;

namespace MadeUpStats.Services
{
    public class UserAccessService : IUserAccessService
    {
        private readonly IUserSession userSession;

        public UserAccessService(IUserSession userSession)
        {
            this.userSession = userSession;
        }

        public bool CurrentUserNeedsToLogin()
        {
            return GetUser().DoesNotExist();
        }

        public bool CurrentUserRolesMatch(IEnumerable<string> roles)
        {
            return roles.Intersect(GetCurrentUserRoles()).Any();
        }

        private IEnumerable<string> GetCurrentUserRoles()
        {
            return GetUser().Roles;
        }

        private IUser GetUser()
        {
            return userSession.GetUser();
        }
    }
}