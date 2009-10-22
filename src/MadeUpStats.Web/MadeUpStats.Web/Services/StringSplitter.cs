using System.Linq;
using System.Text.RegularExpressions;

namespace MadeUpStats.Web.Services
{
    public class StringSplitter
    {
        public string[] SplitCamelCasing(string value)
        {
            return Regex.Replace(value, "([A-Z])", " $1", RegexOptions.Compiled)
                .Split(' ').Where(x => x.Length > 0).ToArray();
        }
    }
}