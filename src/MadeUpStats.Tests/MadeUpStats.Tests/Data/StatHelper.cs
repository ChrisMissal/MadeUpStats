using System;
using MadeUpStats.Domain;

namespace MadeUpStats.Tests.Data
{
    public class StatHelper
    {
        protected static Stat BlankStat
        {
            get { return new Stat("", "", null, DateTime.Now); }
        }
    }
}