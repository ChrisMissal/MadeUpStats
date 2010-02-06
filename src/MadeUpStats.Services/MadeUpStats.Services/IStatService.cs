using System.Collections.Generic;
using MadeUpStats.Domain;

namespace MadeUpStats.Services
{
    public interface IStatService : IKeyableService
    {
        Stat CreateStat(Author author, string title, string description);

        void TagStat(Stat stat, params Tag[] tags);

        Stat GetStat(string key);

        IEnumerable<Stat> GetMostRecentStats(int count);

        void Update(Stat stat);

        IEnumerable<Stat> GetStatsByTag(Tag tag);

        int GetNumberOfStats();
    }
}