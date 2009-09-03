using System;
using System.Collections.Generic;
using MadeUpStats.Framework;

namespace MadeUpStats.Domain
{
    public class Stat
    {
        private readonly List<Tag> tags = new List<Tag>();
        private readonly string description;
        private readonly Author author;
        private readonly DateTime createDate;
        private readonly long id;
        private string title;

        public Stat(string title, string description, Author author, DateTime createDate)
        {
            this.description = description;
            this.author = author;
            this.createDate = createDate;
        }

        public virtual long Id
        {
            get { return id; }
        }

        public virtual string Description
        {
            get { return description; }
        }

        public virtual Author Author
        {
            get { return author; }
        }

        public virtual DateTime CreateDate
        {
            get { return createDate; }
        }

        public virtual IEnumerable<Tag> Tags
        {
            get { return tags; }
        }

        public virtual string Title
        {
            get { return title; }
        }

        public virtual void AddTag(Tag tag)
        {
            Validate.NotNull(tag, "tag");

            if(tags.Contains(tag))
                return;

            tags.Add(tag);
        }
    }
}