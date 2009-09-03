using MadeUpStats.Tests.Fakes;
using MadeUpStats.Web.Controllers;
using Xunit;

namespace MadeUpStats.Tests
{
    public static class TestExtensions
    {
        public static BaseController FakeBaseController
        {
            get { return new FakeBaseController(); }
        }

        public static void ShouldBe(this object @this, object other)
        {
            Assert.Same(other, @this);
        }

        public static void ShouldNotBeNull(this object @this)
        {
            Assert.NotNull(@this);
        }

        public static void ShouldNotEqual(this object @this, object expectedValue)
        {
            Assert.NotEqual(expectedValue, @this);
        }

        public static void ShouldEqual(this object @this, object expectedValue)
        {
            Assert.Equal(expectedValue, @this);
        }

        public static void ShouldBeOfType<T>(this object @this)
        {
            Assert.IsType(typeof (T), @this);
        }
    }
}