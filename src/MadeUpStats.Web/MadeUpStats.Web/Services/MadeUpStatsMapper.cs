using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MadeUpStats.Domain;
using MadeUpStats.Web.Models;

namespace MadeUpStats.Web.Services
{
    public class MadeUpStatsMapper : IMapper
    {
        private static readonly bool initialized;
        private static readonly object dummyLock = new object();

        static MadeUpStatsMapper()
        {
            if(initialized)
                return;

            lock (dummyLock)
            {
                if(initialized)
                    return;

                Mapper.CreateMap<Stat, StatDisplay>();

                initialized = true;
            }
        }

        public IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> sources)
        {
             return Mapper.Map<TSource[], IEnumerable<TDestination>>(sources.ToArray());
        }
    }
}