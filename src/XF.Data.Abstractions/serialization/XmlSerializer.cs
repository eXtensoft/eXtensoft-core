using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Data.Abstractions
{
    public class XmlSerializer : ISerializer
    {
        string ISerializer.ContentType => "application/xml";

        T ISerializer.Deserialize<T>(string data)
        {
            throw new NotImplementedException();
        }

        string ISerializer.Serialize<T>(T data)
        {
            throw new NotImplementedException();

        }
    }
}
