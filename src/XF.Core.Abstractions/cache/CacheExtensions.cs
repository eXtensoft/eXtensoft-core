using System;
using System.Collections.Generic;
using System.Text;
using XF.Caching.Abstractions;

namespace XF.Caching
{
    public static class CacheExtensions
    {
        public static bool Get<T>(this IReadThroughCache<T> cache, out T model) where T : class, new()
        {
            bool b = false;
            model = default(T);
            if (cache.Get<T>(out model))
            {

            }


            return b;
        }
    }
}
