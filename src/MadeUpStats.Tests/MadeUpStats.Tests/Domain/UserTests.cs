using System;
using MadeUpStats.Domain;
using Xunit;

namespace MadeUpStats.Tests.Domain
{
    public class UserTests
    {
        [Fact]
        public void WithRole_should_not_add_duplicate_role()
        {
            var user = new User("Chris").WithRole("a");

            Assert.Throws<InvalidOperationException>(() => user.WithRole("a"));
        }
    }
}