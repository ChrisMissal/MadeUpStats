using System.Collections.Generic;

namespace MadeUpStats.Web.Models.Tag
{
    public class TagDisplay : DisplayBase
    {
        public virtual IEnumerable<Domain.Tag> Tags { get; set; }

        public virtual string TagName { get; set; }

        public virtual IEnumerable<Domain.Stat> Stats { get; set; }
    }
}