using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using XF.Rest.Abstractions;

namespace XF.Caching.Abstractions
{
    public class ConcurrentCache<T> : ICache<T> where T : class, new()
    {

        public IDataService<T> DataService { get; set; }

        private ConcurrentDictionary<string,T> cache = new ConcurrentDictionary<string,T>();

        bool ICache<T>.Invalidate(string key)
        {
            return cache.TryRemove(key, out _);
        }


        bool ICache<T>.TryGet(string key, out T value)
        {
            throw new NotImplementedException();
        }

        void ICache<T>.Set(string key, T model)
        {
            throw new NotImplementedException();
        }
    }
}
