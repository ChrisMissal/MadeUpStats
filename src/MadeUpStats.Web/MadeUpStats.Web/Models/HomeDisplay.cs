using System.Collections.Generic;

namespace MadeUpStats.Web.Models
{
    public class HomeDisplay : DisplayBase
    {
        public IEnumerable<StatDisplay> FeaturedStats { get; set; }
    }
}