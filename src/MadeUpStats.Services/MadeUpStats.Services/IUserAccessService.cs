using System.Collections.Generic;

namespace MadeUpStats.Services
{
    public interface IUserAccessService
    {
        bool CurrentUserNeedsToLogin();

        bool CurrentUserRolesMatch(IEnumerable<string> roles);
    }
}