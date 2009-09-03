using System.Collections.Generic;

namespace MadeUpStats.Web.Models.Home
{
    public class IndexViewModel : ViewModel
    {
        public IEnumerable<Domain.Stat> FeaturedStats { get; set; }
    }
}