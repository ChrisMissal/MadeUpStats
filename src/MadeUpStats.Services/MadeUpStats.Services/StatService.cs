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
            Validate.NotEmpty(description, "description");
            Validate.NotEmpty(title, "title");

            var stat = new Stat(title, description, author, DateTime.Now);
            var key = Keyable.CreateKey(title); 
            stat.SetKey(key);
            statRepository.SaveOrUpdate(stat);
            return stat;
        }

        public void TagStat(Stat stat, params Tag[] tags)
        {
            Array.ForEach(tags, stat.AddTag);
        }

        public Stat GetStat(string key)
        {
            return statRepository.GetByKey(key);
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
            return statRepository.GetByTag(tag);
        }

        public int GetNumberOfStats()
        {
            return statRepository.GetCount();
        }

        public bool ContainsKey(string key)
        {
            var stat = statRepository.GetByKey(key);
            return stat.Exists();
        }
    }
}