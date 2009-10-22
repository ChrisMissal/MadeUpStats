using MadeUpStats.Web.Services;

namespace MadeUpStats.Web.Models
{
    public abstract class DisplayBase
    {
        private static readonly StringSplitter splitter = new StringSplitter();

        public virtual string GetViewName()
        {
            var type = GetType().Name.Replace("Display", string.Empty);
            var strings = splitter.SplitCamelCasing(type);
            return (strings.Length > 1) ? strings[1] : type;
        }
    }
}