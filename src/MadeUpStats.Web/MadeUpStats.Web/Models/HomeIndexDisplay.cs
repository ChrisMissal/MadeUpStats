using System.Collections.Generic;

namespace MadeUpStats.Web.Models
{
    public class HomeIndexDisplay : DisplayBase
    {
        public IEnumerable<StatDisplay> FeaturedStats { get; set; }
    }
}