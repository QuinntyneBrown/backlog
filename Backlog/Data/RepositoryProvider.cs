using System;
using System.Collections.Generic;


namespace Backlog.Data
{
    public class RepositoryProvider : IRepositoryProvider
    {
        public RepositoryProvider(RepositoryFactories repositoryFactories)
        {
            _repositoryFactories = repositoryFactories;
            Repositories = new Dictionary<Type, object>();
        }

        public IDbContext dbContext { get; set; }

        public IRepository<T> GetRepositoryForEntityType<T>() where T : class
        {
            return GetRepository<IRepository<T>>(
                _repositoryFactories.GetRepositoryFactoryForEntityType<T>());
        }

        public virtual T GetRepository<T>(Func<IDbContext, object> factory = null) where T : class
        {
            object repoObj;
            Repositories.TryGetValue(typeof(T), out repoObj);
            if (repoObj != null)
            {
                return (T)repoObj;
            }

            return MakeRepository<T>(factory, dbContext);
        }

        protected Dictionary<Type, object> Repositories { get; private set; }

        protected virtual T MakeRepository<T>(Func<IDbContext, object> factory, IDbContext dbContext)
        {
            var f = factory ?? _repositoryFactories.GetRepositoryFactory<T>();
            if (f == null)
            {
                throw new NotImplementedException("No factory for repository type, " + typeof(T).FullName);
            }
            var repo = (T)f(dbContext);
            Repositories[typeof(T)] = repo;
            return repo;
        }

        public void SetRepository<T>(T repository)
        {
            Repositories[typeof(T)] = repository;
        }

        private RepositoryFactories _repositoryFactories;

    }
}
