using System;
using System.Collections.Generic;
using MadeUpStats.Framework;

namespace MadeUpStats.Domain
{
    public class Stat : IKeyable<string>
    {
        private readonly List<Tag> tags = new List<Tag>();
        private readonly string description;
        private readonly Author author;
        private readonly DateTime createDate;
        private readonly Guid id;
        private readonly string title;
        private string key;

        public Stat(string title, string description, Author author, DateTime createDate)
        {
            id = Guid.NewGuid();

            this.description = description;
            this.title = title;
            this.author = author;
            this.createDate = createDate;
        }

        public virtual Guid Id
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

        public string Key
        {
            get { return key; }
        }

        public virtual void AddTag(Tag tag)
        {
            Validate.NotNull(tag, "tag");

            if(tags.Contains(tag))
                return;

            tags.Add(tag);
        }

        public Stat SetKey(string key)
        {
            this.key = key;
            return this;
        }
    }
}