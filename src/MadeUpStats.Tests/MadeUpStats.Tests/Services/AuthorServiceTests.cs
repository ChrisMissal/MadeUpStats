using System;
using MadeUpStats.Domain;
using MadeUpStats.Services;
using Xunit;

namespace MadeUpStats.Tests.Services
{
    public class AuthorServiceTests
    {
        [Fact]
        public void AuthorService_should_always_return_an_Author_given_a_valid_name()
        {
            new AuthorService().GetAuthor("name").ShouldEqual(new Author("name"));
        }

        [Fact]
        public void AuthorService_should_not_create_an_Author_with_empty_string_for_name()
        {
            Assert.Throws<ArgumentException>(() => new AuthorService().GetAuthor(string.Empty));
        }

        [Fact]
        public void AuthorService_should_not_create_an_Author_with_null_for_name()
        {
            Assert.Throws<ArgumentNullException>(() => new AuthorService().GetAuthor(null));
        }
    }
}