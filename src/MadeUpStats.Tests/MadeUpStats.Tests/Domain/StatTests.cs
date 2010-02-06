using System;
using System.Linq;
using MadeUpStats.Domain;
using Xunit;

namespace MadeUpStats.Tests.Domain
{
    public class StatTests
    {
        [Fact]
        public void Stat_can_have_a_tag_assigned_to_it()
        {
            var tag = new Tag("tag");
            var stat = new Stat("title", "description", new Author("Chris"), DateTime.Now);

            stat.AddTag(tag);
            Assert.Equal(1, stat.Tags.Count());
        }

        [Fact]
        public void Stat_can_have_many_tags_assigned_to_it()
        {
            var tag1 = new Tag("tag1");
            var tag2 = new Tag("tag2");
            var tag3 = new Tag("tag3");
            var stat = new Stat("title", "description", new Author("Chris"), DateTime.Now);

            stat.AddTag(tag1);
            stat.AddTag(tag2);
            stat.AddTag(tag3);
            Assert.Equal(3, stat.Tags.Count());
        }

        [Fact]
        public void Stat_cannot_have_the_same_tag_assigned_to_it_twice()
        {
            var tag = new Tag("tag");
            var stat = new Stat("title", "description", new Author("Chris"), DateTime.Now);

            stat.AddTag(tag);
            stat.AddTag(tag);

            Assert.Equal(1, stat.Tags.Count());
        }

        [Fact]
        public void Stat_should_reflect_the_text_of_a_StatValue_and_Description()
        {
            var stat = new Stat("title", "3 of 5 dentists prefer toothpaste", new Author("Chris"), DateTime.Now);

            Assert.Equal("3 of 5 dentists prefer toothpaste", stat.Description);
        }

        [Fact]
        public void Stat_should_never_equal_null()
        {
            Assert.False(new Stat("title", "description", new Author("Chris"), DateTime.Now).Equals(null));
        }

        [Fact]
        public void Stat_cannot_be_created_with_null_Title()
        {
            Assert.Throws<ArgumentNullException>(() => new Stat(null, "description", new Author("Chris"), DateTime.Now));
        }

        [Fact]
        public void Stat_cannot_be_created_with_empty_Title()
        {
            Assert.Throws<ArgumentException>(() => new Stat("", "description", new Author("Chris"), DateTime.Now));
        }

        [Fact]
        public void Stat_cannot_be_created_with_null_Description()
        {
            Assert.Throws<ArgumentNullException>(() => new Stat("title", null, new Author("chris"), DateTime.Now));
        }

        [Fact]
        public void Stat_cannot_be_created_with_empty_Description()
        {
            Assert.Throws<ArgumentException>(() => new Stat("title", "", new Author("chris"), DateTime.Now));
        }

        [Fact]
        public void Stat_cannot_be_created_with_null_Author()
        {
            Assert.Throws<ArgumentNullException>(() => new Stat("title", "description", null, DateTime.Now));
        }
    }
}