using System;
using System.Collections.Generic;

namespace Backlog.Data
{
    public class RepositoryFactories
    {
        private IDictionary<Type, Func<dynamic, object>> GetFactories()
        {
            return new Dictionary<Type, Func<dynamic, object>>
            {

            };
        }

        public RepositoryFactories()
        {
            _repositoryFactories = GetFactories();
        }

        public Func<dynamic, object> GetRepositoryFactory<T>()
        {

            Func<dynamic, object> factory;
            _repositoryFactories.TryGetValue(typeof(T), out factory);
            return factory;
        }

        public Func<dynamic, object> GetRepositoryFactoryForEntityType<T>() where T : class
        {
            return GetRepositoryFactory<T>() ?? DefaultEntityRepositoryFactory<T>();
        }

        protected virtual Func<dynamic, object> DefaultEntityRepositoryFactory<T>() where T : class
        {
            return dbContext => new EFRepository<T>(dbContext);
        }

        private readonly IDictionary<Type, Func<dynamic, object>> _repositoryFactories;

    }
}
