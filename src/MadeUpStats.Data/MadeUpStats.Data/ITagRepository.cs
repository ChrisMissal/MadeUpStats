using System.Collections.Generic;
using MadeUpStats.Domain;

namespace MadeUpStats.Data
{
    public interface ITagRepository : IRepository<Tag, string>
    {
        IEnumerable<Tag> GetMostPopularTags(int count);

        IEnumerable<Tag> GetTags(int count);
    }
}