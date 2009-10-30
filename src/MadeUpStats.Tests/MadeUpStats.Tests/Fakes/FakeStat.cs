using System;
using MadeUpStats.Domain;

namespace MadeUpStats.Tests.Fakes
{
    public class FakeStat
    {
        public static Stat NewInstance
        {
            get { return new Stat("title", "description", new Author("name"), DateTime.Now); }
        }
    }
}