using System.Collections.Generic;

namespace MadeUpStats.Domain
{
    public interface IUser
    {
        string UserName { get; }
        IEnumerable<string> Roles { get; }
    }
}