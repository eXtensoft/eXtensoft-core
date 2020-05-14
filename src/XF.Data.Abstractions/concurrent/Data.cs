using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Data.Concurrent
{
    public class Data<T> where T : class, new()
    {
        public T Model { get; set; }
        public string Message { get; set; }
    }
}
