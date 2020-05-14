using System;

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
                t = System.Text.Json.JsonSerializer.Deserialize<T>(data);
            }
            return t;
        }

        string ISerializer.Serialize<T>(T data)
        {
            string output = String.Empty;
            if (data != null)
            {
                output = System.Text.Json.JsonSerializer.Serialize(data);
            }
            return output;
        }
    }
}
