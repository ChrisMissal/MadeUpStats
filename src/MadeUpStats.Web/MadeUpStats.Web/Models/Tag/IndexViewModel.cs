using System.Collections.Generic;

namespace MadeUpStats.Web.Models.Tag
{
    public class IndexViewModel : ViewModel
    {
        public virtual IEnumerable<Domain.Tag> Tags { get; set; }

        public virtual string TagName { get; set; }

        public IEnumerable<Domain.Stat> Stats { get; set; }
    }
}