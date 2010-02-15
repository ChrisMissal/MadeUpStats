using System;
using System.Collections.Generic;
using System.Linq;
using MadeUpStats.Domain;
using MadeUpStats.Web.Models;
using mapper = AutoMapper.Mapper;

namespace MadeUpStats.Web.Services
{
    public class Mapper : IMapper
    {
        private static readonly bool initialized;
        private static readonly object dummyLock = new object();

        static Mapper()
        {
            if(initialized)
                return;

            lock (dummyLock)
            {
                if(initialized)
                    return;

                mapper.CreateMap<Stat, StatDisplay>();

                initialized = true;
            }
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return mapper.Map<TSource, TDestination>(source);
        }

        public IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> sources)
        {
             return mapper.Map<TSource[], IEnumerable<TDestination>>(sources.ToArray());
        }
    }
}