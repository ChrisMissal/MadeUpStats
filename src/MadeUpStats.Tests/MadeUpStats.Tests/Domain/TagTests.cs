using System;
using MadeUpStats.Domain;
using Xunit;

namespace MadeUpStats.Tests.Domain
{
    public class TagTests
    {
        [Fact]
        public void Tags_with_same_name_should_be_equal()
        {
            var firstTag = new Tag("tag");
            var secondTag = new Tag("tag");

            Assert.Equal(firstTag, secondTag);
        }

        [Fact]
        public void Tags_cannot_be_created_with_empty_string()
        {
            Assert.Throws<ArgumentException>(() => new Tag(string.Empty));
        }

        [Fact]
        public void Tags_cannot_be_created_with_null()
        {
            Assert.Throws<ArgumentNullException>(() => new Tag(null));
        }

        [Fact]
        public void Tag_should_never_equal_null()
        {
            Assert.False(new Tag("chris").Equals(null));
        }

        [Fact]
        public void Tag_Key_should_be_the_same_as_the_Tag_Name()
        {
            var tag = new Tag("name");
            tag.Name.ShouldEqual(tag.Key);
        }

        [Fact]
        public void Tag_creation_should_throw_error_if_name_is_not_Keyable()
        {
            Assert.Throws<ArgumentException>(() => new Tag("T"));
        }
    }
}