using fss = System.Func<string, string>;

namespace MadeUpStats.Web.Models
{
    public abstract class DisplayBase
    {
        private readonly fss[] typeNameFunctions = new fss[]
        {
            x => x.Replace("Display", string.Empty),
            x => x.Replace("Input", string.Empty),
            x => x.ToLowerInvariant()
        };
        
        public virtual string GetViewName()
        {
            var typeName = GetType().Name;
            foreach (var func in typeNameFunctions)
                typeName = func(typeName);

            return typeName;
        }
    }
}