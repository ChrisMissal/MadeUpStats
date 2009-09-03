using System.Collections.Generic;

namespace MadeUpStats.Data
{
    public interface IRepository<T, T1>
    {
        T GetById(T1 id);

        void SaveOrUpdate(T entity);

        T Delete(T entity);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetMostRecent(int count);
    }
}
