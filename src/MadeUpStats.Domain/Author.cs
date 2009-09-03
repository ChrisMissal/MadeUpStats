namespace MadeUpStats.Domain
{
    public class Author
    {
        private readonly string name;

        public Author(string name)
        {
            this.name = name;
        }

        public virtual string Name
        {
            get { return name; }
        }

        public override bool Equals(object obj)
        {
            var other = obj as Author;
            if(other == null)
                return false;

            return (name.Equals(other.name) || base.Equals(obj));
        }
    }
}