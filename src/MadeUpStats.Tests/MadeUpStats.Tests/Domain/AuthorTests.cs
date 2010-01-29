using System;
using MadeUpStats.Domain;
using Xunit;

namespace MadeUpStats.Tests.Domain
{
    public class AuthorTests
    {
        [Fact]
        public void Author_can_be_created()
        {
            var author = new Author("Chris");

            Assert.Equal("Chris", author.Name);
        }

        [Fact]
        public void Author_will_be_assigned_to_a_stat_after_creating_one()
        {
            var author = new Author("Chris Missal");

            var stat = new Stat(null, null, author, DateTime.Now);

            Assert.Same(stat.Author, author);
        }

        [Fact]
        public void Author_should_never_equal_null()
        {
            new Author("chris").Equals(null).ShouldEqual(false);
        }
    }
}