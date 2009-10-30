using MadeUpStats.Framework;
using Xunit;

namespace MadeUpStats.Tests.Framework
{
    public class KeyableTests
    {
        [Fact]
        public void Strings_should_equal_the_expected_Key_value()
        {
            Keyable.CreateKey("This is a key").ShouldEqual("this-is-a-key");
        }

        [Fact]
        public void Check_if_strings_match_the_regex()
        {
            var regex = Keyable.Regex;

            Assert.True(regex.IsMatch("tag"));
            Assert.True(regex.IsMatch("catch22"));
            Assert.True(regex.IsMatch("abc-d"));
            Assert.True(regex.IsMatch("asp.net-mvc"));
            Assert.False(regex.IsMatch("a b"));
            Assert.False(regex.IsMatch("c|"));
            Assert.False(regex.IsMatch("d+"));
            Assert.False(regex.IsMatch("e="));
        }
    }
}