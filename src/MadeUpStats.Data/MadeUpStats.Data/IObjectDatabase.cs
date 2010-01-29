using System.Collections.Generic;
using MadeUpStats.Domain;

namespace MadeUpStats.Data
{
    public interface IObjectDatabase
    {
        void Delete(Entity entity);

        void Store(Entity entity);

        IEnumerable<T> QueryByExample<T>(Entity entity);

        IEnumerable<T> Query<T>();
    }
}