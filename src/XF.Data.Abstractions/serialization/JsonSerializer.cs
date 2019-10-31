using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Data.Abstractions
{
    public class JsonSerializer : ISerializer
    {
        string ISerializer.ContentType => "application/json";

        T ISerializer.Deserialize<T>(string data)
        {
            T t = default(T);
            if (data != null && !String.IsNullOrWhiteSpace(data))
            {
                t = JsonConvert.DeserializeObject<T>(data);
            }
            return t;
        }

        string ISerializer.Serialize<T>(T data)
        {
            string output = String.Empty;
            if (data != null)
            {
                output = JsonConvert.SerializeObject(data);
            }
            return output;
        }
    }
}
