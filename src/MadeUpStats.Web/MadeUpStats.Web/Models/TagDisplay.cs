using System.Collections.Generic;
using MadeUpStats.Domain;

namespace MadeUpStats.Web.Models
{
    public class TagDisplay : DisplayBase
    {
        public virtual string Name { get; set; }

        public IEnumerable<Stat> Stats { get; set; }
    }
}