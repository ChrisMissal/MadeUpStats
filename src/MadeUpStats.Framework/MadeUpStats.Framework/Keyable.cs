using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MadeUpStats.Framework
{
    public static class Keyable
    {
        private const string KEYABLE_REGEX_PATTERN = "^[A-Za-z0-9\\-\\.]+$";

        private static readonly List<Func<string, string>> stringFuncs = new List<Func<string, string>>();
        private static readonly Func<string, string> removeLeadingAndTrailingSpaces = value => value.Trim();
        private static readonly Func<string, string> stripInvalidCharacters = value => Regex.Replace(value, @"[^a-zA-Z0-9\-]", string.Empty);
        private static readonly Func<string, string> replaceCharactersWithHyphens = value => Regex.Replace(value, @" ", "-");
        private static readonly Func<string, string> makeLowerCase = value => value.ToLowerInvariant();

        static Keyable()
        {
            stringFuncs.Add(makeLowerCase);
            stringFuncs.Add(removeLeadingAndTrailingSpaces);
            stringFuncs.Add(replaceCharactersWithHyphens);
            stringFuncs.Add(stripInvalidCharacters);
        }

        public static Regex Regex
        {
            get { return new Regex(KEYABLE_REGEX_PATTERN);}
        }

        public static string CreateKey(string key)
        {
            stringFuncs.ForEach(func => { key = func(key); });
            return key;
        }
    }
}