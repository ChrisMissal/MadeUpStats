using System;

namespace MadeUpStats.Framework
{
    public static class Validate
    {
        private const string NOT_EMPTY = "Argument {0} cannot be empty.";
        private const string NOT_ZERO_OR_LESS = "{0} cannot be zero or less.";
        private const string NOT_EQUAL = "{0} and {1} cannot be equal.";
        private const string GREATER_THAN_OR_EQUAL_TO_ZERO = "{0} is not greater than or equal to zero.";
        private const string LESS_THAN_OR_EQUAL_TO_ONE_HUNDRED = "{0} is not less than or equal to one hundred.";

        public static void NotNull(object obj, string paramName)
        {
            if(obj == null)
                throw new ArgumentNullException(paramName);
        }

        public static void NotEmpty(object obj, string paramName)
        {
            if (obj.Equals(string.Empty))
                throw new ArgumentException(NOT_EMPTY.FormatWith(paramName), paramName);
        }

        public static void NotZeroOrLess(int value, string paramName)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(paramName, value, NOT_ZERO_OR_LESS.FormatWith(paramName));
        }

        public static void NotEqual(int first, int second)
        {
            if (first == second)
                throw new ArgumentException(NOT_EQUAL.FormatWith(first, second));
        }

        public static void GreaterThanOrEqualToZero(decimal value)
        {
            if(value < 0m)
                throw new ArgumentOutOfRangeException(GREATER_THAN_OR_EQUAL_TO_ZERO.FormatWith(value));
        }

        public static void LessThanOrEqualToOneHundred(decimal value)
        {
            if (value > 100m)
                throw new ArgumentOutOfRangeException(LESS_THAN_OR_EQUAL_TO_ONE_HUNDRED.FormatWith(value));
        }
    }
}