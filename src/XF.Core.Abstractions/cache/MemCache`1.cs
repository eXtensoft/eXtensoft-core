using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using XF.Caching.Abstractions;
using XF.Core.Abstractions;

namespace XF.Caching
{
    public class MemCache<T> : ICache<T> where T : class, new()
    {
        private IMemoryCache _Cache;
        public MemCache(IMemoryCache cache)
        {
            _Cache = cache;
        }
        bool ICache<T>.Invalidate(string key)
        {
            
            _Cache.Remove(key);
            return true;
        }

        void ICache<T>.Set(string key, T model)
        {
            _Cache.Set<T>(key, model);
        }

        bool ICache<T>.TryGet(string key, out T value)
        {
            return _Cache.TryGetValue<T>(key, out value);
        }
    }
}
