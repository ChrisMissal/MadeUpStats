using MadeUpStats.Framework;

namespace MadeUpStats.Domain
{
    public class Tag : IKeyable<string>
    {
        private readonly string name;

        public Tag(string name)
        {
            Validate.NotNull(name, "name");
            Validate.NotEmpty(name, "name");

            this.name = name;
        }

        public virtual string Name
        {
            get { return name; }
        }

        public override bool Equals(object obj)
        {
            var other = obj as Tag;
            if(other == null)
                return false;

            return name.Equals(other.name) || base.Equals(obj);
        }

        public string Key
        {
            get { return name; }
        }
    }
}