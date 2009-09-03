namespace MadeUpStats.Web.Models.Stat
{
    public class CreateDataModel : DataModel
    {
        public override long Id { get; set; }
        public virtual string Description { get; set; }
        public virtual string TagString { get; set; }
        public virtual string StatValue { get; set; }
        public virtual string Author { get; set; }
        public virtual string Title { get; set; }
    }
}