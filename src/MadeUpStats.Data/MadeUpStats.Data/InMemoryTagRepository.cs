using System;
using System.Collections.Generic;
using System.Linq;
using MadeUpStats.Domain;

namespace MadeUpStats.Data
{
    public class InMemoryTagRepository : ITagRepository
    {
        private readonly List<Tag> tags = new List<Tag>();

        public Tag GetById(long id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IEnumerable<Tag> GetMostPopularTags(int count)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tag> GetTags(int count)
        {
            return tags.Take(count);
        }
    }
}