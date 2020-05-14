using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Caching.Abstractions
{
    public interface ICache<T> where T : class, new()
    {
        void Set(string key, T model);
        bool TryGet(string key, out T model);
        bool Invalidate(string key);
    }
}
