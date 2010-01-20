using System;
using MadeUpStats.Domain;
using MadeUpStats.Services;
using Moq;
using Xunit;

namespace MadeUpStats.Tests.Services
{
    public class AuthorServiceTests
    {
        private Mock<IUserSession> userSession;

        [Fact]
        public void AuthorService_should_return_null_if_userSession_user_is_null()
        {
            var service = GetAuthorService();
            userSession.Setup(x => x.GetUser()).Returns((IUser) null);

            var author = service.GetLoggedInAuthor();

            Assert.Null(author);
        }

        [Fact]
        public void AuthorService_should_always_return_an_Author_given_a_valid_name()
        {
            var service = GetAuthorService();
            var user = new Mock<IUser>();
            user.Setup(x => x.UserName).Returns("name");

            userSession.Setup(x => x.GetUser()).Returns(user.Object);

            service.GetLoggedInAuthor().ShouldEqual(new Author("name"));
        }

        [Fact]
        public void AuthorService_should_not_create_an_Author_with_empty_string_for_name()
        {
            var service = GetAuthorService();
            var user = new Mock<IUser>();
            user.Setup(x => x.UserName).Returns("");

            userSession.Setup(x => x.GetUser()).Returns(user.Object);

            Assert.Throws<ArgumentException>(() => service.GetLoggedInAuthor());
        }

        [Fact]
        public void AuthorService_should_not_create_an_Author_with_null_for_name()
        {
            var service = GetAuthorService();
            var user = new Mock<IUser>();
            user.Setup(x => x.UserName).Returns((string)null);

            userSession.Setup(x => x.GetUser()).Returns(user.Object);

            Assert.Throws<ArgumentNullException>(() => service.GetLoggedInAuthor());
        }

        private AuthorService GetAuthorService()
        {
            userSession = new Mock<IUserSession>();
            return new AuthorService(userSession.Object);
        }
    }
}