using System;
using MadeUpStats.Data;
using MadeUpStats.Services;
using Moq;
using Xunit;

namespace MadeUpStats.Tests.Services
{
    public class HttpUserSessionTests
    {
        private Mock<IUserRepository> userRepository;

        [Fact]
        public void TrySignIn_should_call_Repository_with_UserName()
        {
            var userSession = GetUserSession();

            userSession.TrySignIn("userName", "password");

            userRepository.Verify(x => x.GetUser("userName"));
        }

        private HttpUserSession GetUserSession()
        {
            userRepository = new Mock<IUserRepository>();

            return new HttpUserSession(userRepository.Object);
        }
    }
}