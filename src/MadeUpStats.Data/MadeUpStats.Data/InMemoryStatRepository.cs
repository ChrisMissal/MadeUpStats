using System.Collections.Generic;
using System.Linq;
using MadeUpStats.Domain;

namespace MadeUpStats.Data
{
    public class InMemoryStatRepository : IStatRepository
    {
        private long statId;
        private readonly Dictionary<long, Stat> stats = new Dictionary<long, Stat>();

        public Stat GetById(long id)
        {
            if(!stats.ContainsKey(id)) return null;

            var stat = stats[id];
            return stat;
        }

        public void SaveOrUpdate(Stat entity)
        {
            if (stats.Values.Contains(entity))
            {
                stats[entity.Id] = entity;
                return;
            }

            var id = ++statId;
            stats.Add(id, entity);
        }

        public Stat Delete(Stat entity)
        {
            var id = stats.FirstOrDefault(x => x.Value.Equals(entity)).Key;
            if(stats.ContainsKey(id))
            {
                stats.Remove(id);
                return entity;
            }
            return null;
        }

        public IEnumerable<Stat> GetAll()
        {
            return stats.Values;
        }

        public IEnumerable<Stat> GetMostRecent(int count)
        {
            return stats.Values.OrderByDescending(x => x.CreateDate).Take(count);
        }
    }
}