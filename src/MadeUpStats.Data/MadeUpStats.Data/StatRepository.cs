using System;
using System.Collections.Generic;
using System.Linq;
using MadeUpStats.Domain;

namespace MadeUpStats.Data
{
    public class StatRepository : IStatRepository
    {
        private readonly IObjectDatabase objectDatabase;

        public StatRepository(IObjectDatabase objectDatabase)
        {
            this.objectDatabase = objectDatabase;
        }

        public void SaveOrUpdate(Stat entity)
        {
            objectDatabase.Store(entity);
        }

        public Stat Delete(Stat entity)
        {
            objectDatabase.Delete(entity);
            return entity;
        }

        public IEnumerable<Stat> GetAll()
        {
            return objectDatabase.QueryByExample<Stat>(default(Stat));
        }

        public IEnumerable<Stat> GetMostRecent(int count)
        {
            return objectDatabase.Query<Stat>()
                .OrderByDescending(stat => stat.CreateDate)
                .Take(count);
        }

        public Stat GetByKey(string key)
        {
            return objectDatabase.Query<Stat>().FirstOrDefault(stat => stat.Key == key);
        }

        public int GetCount()
        {
            return objectDatabase.Query<Stat>().Count();
        }

        public IEnumerable<Stat> GetByTag(Tag tag)
        {
            return objectDatabase.Query<Stat>().Where(stat => stat.Tags.Any(t => t.Key == tag.Key));
        }
    }
}