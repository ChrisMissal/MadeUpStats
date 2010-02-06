using System.Collections.Generic;

namespace MadeUpStats.Web.Services
{
    public interface IMapper
    {
        IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> sources);
    }
}