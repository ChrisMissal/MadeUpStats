using System;
using MadeUpStats.Data;
using MadeUpStats.Domain;
using MadeUpStats.Services;
using Moq;
using Xunit;

namespace MadeUpStats.Tests.Services
{
    public class UserAccessServiceTests
    {
        private Mock<IUserSession> userSession;

        [Fact]
        public void CurrentUserNeedsToLogin_should_return_true_if_user_is_not_signed_in_to_session()
        {
            var userAccessService = GetService();
            userSession.Setup(x => x.GetUser()).Returns(default(IUser));

            var result = userAccessService.CurrentUserNeedsToLogin();

            result.ShouldBeTrue();
        }

        [Fact]
        public void CurrentUserNeedsToLogin_should_return_false_if_user_is_signed_in_to_session()
        {
            var userAccessService = GetService();
            userSession.Setup(x => x.GetUser()).Returns(new User("user"));

            var result = userAccessService.CurrentUserNeedsToLogin();

            result.ShouldBeFalse();
        }

        [Fact]
        public void CurrentUserRolesMatch_should_return_false_if_list_and_user_roles_dont_intersect()
        {
            var userAccessService = GetService();
            userSession.Setup(x => x.GetUser())
                .Returns(new User("ronald").WithRole("1").WithRole("2").WithRole("3"));

            var result = userAccessService.CurrentUserRolesMatch(new[] {"a", "b", "c"});

            result.ShouldBeFalse();
        }

        [Fact]
        public void CurrentUserRolesMatch_should_return_true_if_list_matches_any_user_role()
        {
            var userAccessService = GetService();
            userSession.Setup(x => x.GetUser())
                .Returns(new User("ronald").WithRole("a").WithRole("b"));

            var result = userAccessService.CurrentUserRolesMatch(new[] {"", "a", "aa"});

            result.ShouldBeTrue();
        }

        private UserAccessService GetService()
        {
            userSession = new Mock<IUserSession>();

            return new UserAccessService(userSession.Object);
        }
    }
}