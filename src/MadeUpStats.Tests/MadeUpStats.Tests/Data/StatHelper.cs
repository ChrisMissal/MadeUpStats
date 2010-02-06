using System;
using MadeUpStats.Domain;

namespace MadeUpStats.Tests.Data
{
    public abstract class StatHelper
    {
        protected static Stat BlankStat
        {
            get { return new Stat("blank", "stat", new Author("author"), DateTime.Now); }
        }
    }
}