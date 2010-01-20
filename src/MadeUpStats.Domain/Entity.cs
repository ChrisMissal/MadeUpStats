using System;

namespace MadeUpStats.Domain
{
    public abstract class Entity
    {
        protected Guid id;

        protected Entity()
        {
            id = Guid.NewGuid();
        }

        public virtual Guid Id
        {
            get { return id; }
        }
    }
}