using System;
using MadeUpStats.Web.Services;
using Xunit;

namespace MadeUpStats.Tests.Web.Services
{
    public class DateFormatterTests
    {
        [Fact]
        public void Expected_strings_for_date_values()
        {
            "one second ago".ShouldEqual(TimeWithin(LessThanOneSecondAgo));
            "one second ago".ShouldEqual(TimeWithin(1.SecondsAgo()));
            "nine seconds ago".ShouldEqual(TimeWithin(9.SecondsAgo()));
            "five seconds ago".ShouldEqual(TimeWithin(5.SecondsAgo()));
            "25 seconds ago".ShouldEqual(TimeWithin(25.SecondsAgo()));
            "45 seconds ago".ShouldEqual(TimeWithin(45.SecondsAgo()));
            "59 seconds ago".ShouldEqual(TimeWithin(59.SecondsAgo()));

            "one minute ago".ShouldEqual(TimeWithin(60.SecondsAgo()));
            "one minute ago".ShouldEqual(TimeWithin(1.MinutesAgo()));
            "two minutes ago".ShouldEqual(TimeWithin(2.MinutesAgo()));
            "10 minutes ago".ShouldEqual(TimeWithin(10.MinutesAgo()));
            "59 minutes ago".ShouldEqual(TimeWithin(59.MinutesAgo()));

            "one hour ago".ShouldEqual(TimeWithin(1.HoursAgo()));
            "three hours ago".ShouldEqual(TimeWithin(3.HoursAgo()));
            "eight hours ago".ShouldEqual(TimeWithin(8.HoursAgo()));
            "12 hours ago".ShouldEqual(TimeWithin(12.HoursAgo()));
            "17 hours ago".ShouldEqual(TimeWithin(17.HoursAgo()));
            "23 hours ago".ShouldEqual(TimeWithin(23.HoursAgo()));

            "one day ago".ShouldEqual(TimeWithin(1.DaysAgo()));
            "two days ago".ShouldEqual(TimeWithin(2.DaysAgo()));
            "four days ago".ShouldEqual(TimeWithin(4.DaysAgo()));
            "six days ago".ShouldEqual(TimeWithin(6.DaysAgo()));

            var fallThrough = DateTime.Now.AddDays(-12);
            fallThrough.ToString("MMM dd, yyyy").ShouldEqual(TimeWithin(DateTime.Now - fallThrough));
        }

        protected TimeSpan LessThanOneSecondAgo
        {
            get { return new TimeSpan(0, 0, 0, 0, 923); }
        }

        private static string TimeWithin(TimeSpan timeSpan)
        {
            return new DateFormatter().GetFormat(DateTime.Now, DateTime.Now - timeSpan);
        }
    }
}