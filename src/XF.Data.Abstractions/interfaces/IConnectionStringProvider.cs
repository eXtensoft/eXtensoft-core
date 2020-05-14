using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Data.Abstractions
{
    public interface IConnectionStringProvider
    {
        string Get(string key);
        string Get<T>() where T : class, new();
    }
}
