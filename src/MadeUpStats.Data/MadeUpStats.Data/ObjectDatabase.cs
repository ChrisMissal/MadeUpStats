using System.Collections.Generic;
using Db4objects.Db4o;
using MadeUpStats.Domain;

namespace MadeUpStats.Data
{
    public class ObjectDatabase : IObjectDatabase
    {
        static readonly object dummyLock = new object();

        private static IObjectContainer objectContainer;
        private readonly IDataConfiguration dataConfiguration;

        public ObjectDatabase(IDataConfiguration dataConfiguration)
        {
            this.dataConfiguration = dataConfiguration;

            EnsureInitialized();
        }

        public IObjectContainer ObjectContainer
        {
            get
            {
                EnsureInitialized();
                return objectContainer;
            }
        }

        private void EnsureInitialized()
        {
            if(objectContainer != null)
                return;

            lock(dummyLock)
            {
                if(objectContainer != null)
                    return;

                objectContainer = Db4oFactory.OpenFile(dataConfiguration.Path);
            }
        }

        public void Delete(Entity entity)
        {
            objectContainer.Delete(entity);
        }

        public void Store(Entity entity)
        {
            objectContainer.Store(entity);
        }

        public IEnumerable<T> QueryByExample<T>(Entity entity)
        {
            var entities = objectContainer.QueryByExample(entity);
            while (entities.HasNext())
                yield return (T)entities.Next();
        }

        public IEnumerable<T> Query<T>()
        {
            return objectContainer.Query<T>();
        }
    }
}