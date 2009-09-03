using System;
using System.Linq;
using MadeUpStats.Domain;
using Moq;
using Xunit;

namespace MadeUpStats.Tests.Domain
{
    public class StatTests
    {
        [Fact]
        public void Stat_can_have_a_tag_assigned_to_it()
        {
            var tag = new Tag("Tag");
            var stat = new Stat(null, null, null, DateTime.Now);

            stat.AddTag(tag);
            Assert.Equal(1, stat.Tags.Count());
        }

        [Fact]
        public void Stat_can_have_many_tags_assigned_to_it()
        {
            var tag1 = new Tag("Tag1");
            var tag2 = new Tag("Tag2");
            var tag3 = new Tag("Tag3");
            var stat = new Stat(null, null, null, DateTime.Now);

            stat.AddTag(tag1);
            stat.AddTag(tag2);
            stat.AddTag(tag3);
            Assert.Equal(3, stat.Tags.Count());
        }

        [Fact]
        public void Stat_cannot_have_the_same_tag_assigned_to_it_twice()
        {
            var tag = new Tag("Tag");
            var stat = new Stat(null, null, null, DateTime.Now);

            stat.AddTag(tag);
            stat.AddTag(tag);

            Assert.Equal(1, stat.Tags.Count());
        }

        [Fact]
        public void Stat_should_reflect_the_text_of_a_StatValue_and_Description()
        {
            var stat = new Stat("", "3 of 5 dentists prefer toothpaste", null, DateTime.Now);

            Assert.Equal("3 of 5 dentists prefer toothpaste", stat.Description);
        }

        [Fact]
        public void Stat_should_never_equal_null()
        {
            Assert.False(new Stat(null, null, null, DateTime.Now).Equals(null));
        }
    }
}