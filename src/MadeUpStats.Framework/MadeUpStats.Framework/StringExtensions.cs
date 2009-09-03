namespace MadeUpStats.Framework
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string @this)
        {
            return string.IsNullOrEmpty(@this);
        }

        public static string FormatWith(this string @this, params object[] args)
        {
            return string.Format(@this, args);
        }
    }
}
