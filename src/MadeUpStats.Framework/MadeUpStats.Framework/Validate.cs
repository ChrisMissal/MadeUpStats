using System;

namespace MadeUpStats.Framework
{
    public static class Validate
    {
        private const string NOT_EMPTY = "{0} cannot be empty.";
        private const string NOT_NULL = "{0} is not set.";

        public static void NotNull(object obj, string paramName)
        {
            if(obj == null)
                throw new ArgumentNullException(paramName, NOT_NULL.FormatWith(paramName));
        }

        public static void NotEmpty(object obj, string paramName)
        {
            if (obj.Equals(string.Empty))
                throw new ArgumentException(NOT_EMPTY.FormatWith(paramName), paramName);
        }
    }
}