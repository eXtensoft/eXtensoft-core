using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using XF.Core.Abstractions;

namespace XF.Caching.Abstractions
{
    public interface ICache
    {
        bool TryGet<T>(object key, out T value);
        T Put<T>(object key, T model, IParameters parameters);
        T Post<T>(object key, T model);
        bool Invalidate<T>(object key);
    }
}
