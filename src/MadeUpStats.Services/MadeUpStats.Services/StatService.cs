using System;
using System.Collections.Generic;
using MadeUpStats.Data;
using MadeUpStats.Domain;
using MadeUpStats.Framework;

namespace MadeUpStats.Services
{
    public class StatService : IStatService
    {
        private readonly IStatRepository statRepository;

        public StatService(IStatRepository statRepository)
        {
            this.statRepository = statRepository;
        }

        public Stat CreateStat(Author author, string title, string description)
        {
            Validate.NotNull(description, "description");
            Validate.NotEmpty(description, "description");

            var stat = new Stat(title, description, author, DateTime.Now);
            statRepository.SaveOrUpdate(stat);
            return stat;
        }

        public void TagStat(Stat stat, params Tag[] tags)
        {
            Array.ForEach(tags, stat.AddTag);
        }

        public Stat GetStat(long id)
        {
            return statRepository.GetById(id);
        }

        public IEnumerable<Stat> GetMostRecentStats(int count)
        {
            return statRepository.GetMostRecent(count);
        }

        public void Update(Stat stat)
        {
            statRepository.SaveOrUpdate(stat);
        }

        public IEnumerable<Stat> GetStatsByTag(Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}