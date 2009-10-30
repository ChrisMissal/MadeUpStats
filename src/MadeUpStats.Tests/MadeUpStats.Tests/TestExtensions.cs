using System;
using Xunit;

namespace MadeUpStats.Tests
{
    public static class TestExtensions
    {
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

        public static void ShouldBeTrue(this bool @this)
        {
            Assert.True(@this);
        }

        public static void ShouldBeFalse(this bool @this)
        {
            Assert.False(@this);
        }

        public static void ShouldBeOfType<T>(this object @this)
        {
            Assert.IsType(typeof (T), @this);
        }

        public static TimeSpan SecondsAgo(this int @this)
        {
            return new TimeSpan(0, 0, 0, @this);
        }

        public static TimeSpan MinutesAgo(this int @this)
        {
            return new TimeSpan(0, 0, @this, 0);
        }

        public static TimeSpan HoursAgo(this int @this)
        {
            return new TimeSpan(@this, 0, 0);
        }

        public static TimeSpan DaysAgo(this int @this)
        {
            return new TimeSpan(@this, 0, 0, 0);
        }
    }
}