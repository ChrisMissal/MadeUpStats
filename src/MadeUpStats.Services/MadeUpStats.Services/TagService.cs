using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MadeUpStats.Data;
using MadeUpStats.Domain;
using MadeUpStats.Framework;

namespace MadeUpStats.Services
{
    public class TagService : ITagService
    {
        private readonly List<Func<string, string>> stringFuncs = new List<Func<string, string>>();
        private static readonly Func<string, string> stripInvalidCharacters = value => Regex.Replace(value, @"[^a-zA-Z0-9\-]", string.Empty);
        private static readonly Func<string, string> replaceCharactersWithHyphens = value => Regex.Replace(value, @" ", "-");

        private readonly Regex tagsRegex = new Regex(@"(?:,|^)(""[^""]*""|[^,]*)", RegexOptions.IgnorePatternWhitespace);

        private readonly ITagRepository tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
            stringFuncs.Add(replaceCharactersWithHyphens);
            stringFuncs.Add(stripInvalidCharacters);
        }

        public IEnumerable<Tag> CreateTags(string multiTagString)
        {
            // Return a null collection if the tag string is empty
            if(multiTagString.IsNullOrEmpty())
                yield return null;

            // Otherwise, break the string apart and return new tags based on the
            // regex match values. One tag per match.
            var matches = tagsRegex.Matches(multiTagString);
            foreach (Match m in matches)
            {
                var value = m.Groups[1].Value;
                if(value.IsNullOrEmpty())
                    continue;
                stringFuncs.ForEach(func => { value = func(value); });
                var tag = new Tag(value);
                tagRepository.SaveOrUpdate(tag);
                yield return tag;
            }
        }

        public Tag DeleteTag(Tag tag)
        {
            var deletedTag = tagRepository.Delete(tag);
            return deletedTag;
        }

        public IEnumerable<Tag> GetMostPopularTags(int count)
        {
            var tags = tagRepository.GetMostPopularTags(count);
            return tags;
        }

        public IEnumerable<Tag> GetTags(int count)
        {
            var tags = tagRepository.GetTags(count);
            return tags;
        }
    }
}