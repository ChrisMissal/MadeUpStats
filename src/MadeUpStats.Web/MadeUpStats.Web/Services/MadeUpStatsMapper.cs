using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MadeUpStats.Domain;
using MadeUpStats.Web.Models;

namespace MadeUpStats.Web.Services
{
    public class MadeUpStatsMapper : IMapper
    {
        static MadeUpStatsMapper()
        {
            Mapper.CreateMap<Stat, StatDisplay>();
        }

        public TDestination Map<TDestination, TSource>(TSource source, TDestination destination)
        {
            return Mapper.Map(source, destination);
        }

        public IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> sources)
        {
             return Mapper.Map<TSource[], IEnumerable<TDestination>>(sources.ToArray());
        }
    }
}