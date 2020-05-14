using System;
using System.Collections.Generic;
using System.Text;
using XF.Rest.Abstractions;

namespace XF.Caching.Abstractions
{
    public interface IReadThroughCache<T> : IDataService<T> where T : class, new()
    {
        bool TryGet(string key, out T value);
        bool Invalidate(string key);
    }
}
