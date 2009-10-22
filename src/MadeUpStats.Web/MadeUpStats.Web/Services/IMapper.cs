using System.Collections.Generic;

namespace MadeUpStats.Web.Services
{
    public interface IMapper
    {
        TDestination Map<TDestination, TSource>(TSource source, TDestination destination);

        IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> sources);
    }
}