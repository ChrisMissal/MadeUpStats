using System.Collections.Generic;

namespace MadeUpStats.Web.Services
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
        IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> sources);
    }
}