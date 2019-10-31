using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Data.Abstractions
{
    public interface ISerializer
    {
        string ContentType { get; }
        string Serialize<T>(T data) where T : class, new();
        T Deserialize<T>(string data) where T : class, new();
    }
}
