using System.Collections.Generic;
using MadeUpStats.Domain;

namespace MadeUpStats.Services
{
    public interface ITagService
    {
        IEnumerable<Tag> CreateTags(string multiTagString);

        //Tag CreateTag(string tagName);

        Tag DeleteTag(Tag tag);

        IEnumerable<Tag> GetMostPopularTags(int count);

        IEnumerable<Tag> GetTags(int count);
    }
}
