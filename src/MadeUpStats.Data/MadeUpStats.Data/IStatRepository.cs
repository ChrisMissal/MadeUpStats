using System.Collections.Generic;
using MadeUpStats.Domain;

namespace MadeUpStats.Data
{
    public interface IStatRepository : IRepository<Stat, string>
    {
        IEnumerable<Stat> GetByTag(Tag tag);
    }
}