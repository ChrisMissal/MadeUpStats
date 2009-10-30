using System.Collections.Generic;
using MadeUpStats.Framework;

namespace MadeUpStats.Data
{
    public interface IRepository<T, T1> where T : IKeyable<T1>
    {
        void SaveOrUpdate(T entity);

        T Delete(T entity);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetMostRecent(int count);

        T GetByKey(T1 key);
    }
}
