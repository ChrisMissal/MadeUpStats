using System.Collections.Generic;
using MadeUpStats.Domain;

namespace MadeUpStats.Web.Models
{
    public class AllTagsDisplay : DisplayBase
    {
        public virtual IEnumerable<Tag> Tags { get; set; }
    }
}