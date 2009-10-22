using System;

namespace MadeUpStats.Web.Models
{
    public class StatDisplay : DisplayBase
    {
        public virtual long Id { get; set; }
        public virtual string StatText { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime CreateDate { get; set; }
    }
}