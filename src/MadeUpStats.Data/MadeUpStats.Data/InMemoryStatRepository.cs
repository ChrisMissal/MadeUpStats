using System;
using System.Collections.Generic;
using System.Linq;
using MadeUpStats.Domain;

namespace MadeUpStats.Data
{
    public class InMemoryStatRepository : IStatRepository
    {
        private readonly Dictionary<Guid, Stat> stats = new Dictionary<Guid, Stat>();

        public void SaveOrUpdate(Stat entity)
        {
            if (stats.Values.Contains(entity))
            {
                stats[entity.Id] = entity;
                return;
            }

            stats.Add(entity.Id, entity);
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

        public Stat GetByKey(string key)
        {
            return stats.Values.FirstOrDefault(x => x.Key == key);
        }
    }
}