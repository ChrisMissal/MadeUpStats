using System;
using MadeUpStats.Framework;

namespace MadeUpStats.Web.Services
{
    public class DateFormatter
    {
        private static readonly string[] digits = {"one", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

        private static readonly Func<TimeSpan, string> daysFunc = 
                span => getFormat(span.Days, 7, "day");
        private static readonly Func<TimeSpan, string> hoursFunc =
                span => getFormat(span.Hours, 10, "hour");
        private static readonly Func<TimeSpan, string> minutesFunc =
                span => getFormat(span.Minutes, 10, "minute");
        private static readonly Func<TimeSpan, string> secondsFunc =
                span => getFormat(span.Seconds, 10, "second");

        public virtual string GetFormat(DateTime currentDateTime, DateTime otherDateTime)
        {
            var timeDifference = currentDateTime - otherDateTime;

            if (timeDifference < TimeSpan.FromMinutes(1))
                return secondsFunc(timeDifference);

            if (timeDifference < TimeSpan.FromHours(1))
                return minutesFunc(timeDifference);

            if (timeDifference < TimeSpan.FromDays(1))
                return hoursFunc(timeDifference);

            if (timeDifference < TimeSpan.FromDays(7))
                return daysFunc(timeDifference);

            return otherDateTime.ToString("MMM dd, yyyy");
        }

        private static string getFormat(int value, int ceiling, string datePart)
        {
            return ((value < ceiling) ? digits[value] : value.ToString()) +
                   " {0}{1} ago".FormatWith(datePart, (value > 1) ? "s" : string.Empty);
        }
    }
}