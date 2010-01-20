namespace MadeUpStats.Framework
{
    public static class ObjectExtensions
    {
        public static bool Exists(this object @this)
        {
            return @this != null;
        }

        public static bool DoesNotExist(this object @this)
        {
            return !Exists(@this);
        }
    }
}