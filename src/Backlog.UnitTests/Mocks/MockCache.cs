using Backlog.Features.Core;
using System;
using System.Threading.Tasks;

namespace Backlog.UnitTests.Mocks
{
    public class MockCache : ICache
    {
        public void Add(object objectToCache, string key)
        {
            throw new NotImplementedException();
        }

        public void Add<T>(object objectToCache, string key)
        {
            throw new NotImplementedException();
        }

        public void Add<T>(object objectToCache, string key, double cacheDuration)
        {
            throw new NotImplementedException();
        }

        public void ClearAll()
        {
            throw new NotImplementedException();
        }

        public bool Exists(string key)
        {
            throw new NotImplementedException();
        }

        public TResponse FromCacheOrService<TResponse>(Func<TResponse> action, string key)
        {
            throw new NotImplementedException();
        }

        public TResponse FromCacheOrService<TResponse>(Func<TResponse> action, string key, double cacheDuration)
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> FromCacheOrServiceAsync<TResponse>(Func<Task<TResponse>> action, string key)
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> FromCacheOrServiceAsync<TResponse>(Func<Task<TResponse>> action, string key, double cacheDuration)
        {
            throw new NotImplementedException();
        }

        public object Get(string key)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }
    }
}
