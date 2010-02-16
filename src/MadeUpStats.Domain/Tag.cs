using System;
using MadeUpStats.Framework;

namespace MadeUpStats.Domain
{
    public class Tag : IKeyable<string>
    {
        private readonly string name;
        private readonly DateTime createDate;

        public Tag(string name)
        {
            Validate.Keyable(name, "name");

            this.name = name;
            createDate = DateTime.Now;
        }

        public virtual string Name
        {
            get { return name; }
        }

        public virtual DateTime CreateDate
        {
            get { return createDate; }
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