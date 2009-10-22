namespace MadeUpStats.Web.Models
{
    public class StatInput : InputBase
    {
        public virtual string Description { get; set; }
        public virtual string TagString { get; set; }
        public virtual string Author { get; set; }
        public virtual string Title { get; set; }
    }
}