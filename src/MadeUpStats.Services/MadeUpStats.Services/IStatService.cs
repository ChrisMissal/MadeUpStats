using System.Collections.Generic;
using MadeUpStats.Domain;

namespace MadeUpStats.Services
{
    public interface IStatService
    {
        Stat CreateStat(Author author, string title, string description);

        void TagStat(Stat stat, params Tag[] tags);

        StatPreview GetStatPreview(IStatValue statValue, string description);

        Stat GetStat(long id);

        IEnumerable<Stat> GetMostRecentStats(int count);

        void Update(Stat stat);
    }
}