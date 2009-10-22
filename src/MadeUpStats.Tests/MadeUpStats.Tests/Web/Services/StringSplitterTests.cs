using MadeUpStats.Web.Services;
using Xunit;

namespace MadeUpStats.Tests.Web.Services
{
    public class StringSplitterTests
    {
        [Fact]
        public void StringSplitter_should_split_strings_as_expected()
        {
            SplitCamelCase("class").ShouldEqual(new[] {"class"});
            SplitCamelCase("StringSplitter").ShouldEqual(new[] { "String", "Splitter" });
            SplitCamelCase("ChristopherMichaelMissal").ShouldEqual(new[] { "Christopher", "Michael", "Missal" });
        }

        private static string[] SplitCamelCase(string value)
        {
            var splitter = new StringSplitter();
            return splitter.SplitCamelCasing(value);
        }
    }
}