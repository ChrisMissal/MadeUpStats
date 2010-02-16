using System;
using System.Collections.Generic;
using System.Linq;
using MadeUpStats.Domain;

namespace MadeUpStats.Data
{
    public class TagRepository : ITagRepository
    {
        private readonly IStatRepository statRepository;
        private readonly List<Tag> tags = new List<Tag>();

        public TagRepository(IStatRepository statRepository)
        {
            this.statRepository = statRepository;
        }

        public void SaveOrUpdate(Tag tag)
        {
            if(!tags.Contains(tag))
                tags.Add(tag);
        }

        public Tag Delete(Tag tag)
        {
            if (tags.Contains(tag))
                tags.Remove(tag);

            return tag;
        }

        public IEnumerable<Tag> GetAll()
        {
            return tags;
        }

        public IEnumerable<Tag> GetMostRecent(int count)
        {
            return GetAll()
                .OrderByDescending(x => x.CreateDate)
                .Take(count);
        }

        public Tag GetByKey(string key)
        {
            return tags.FirstOrDefault(x => x.Key == key);
        }

        public int GetCount()
        {
            return tags.Count;
        }

        public IEnumerable<Tag> GetMostPopularTags(int count)
        {
            // this seems ridiculous right now... eventually it will go away
            return statRepository.GetAll()
                .OrderByDescending(x => x.Tags.Count())
                .Take(count)
                .SelectMany(x => x.Tags);
        }

        public IEnumerable<Tag> GetTags(int count)
        {
            return tags.Take(count);
        }
    }
}