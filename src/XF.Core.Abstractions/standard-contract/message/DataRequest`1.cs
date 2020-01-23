using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using XF.Core.Abstractions;

namespace XF.Rest.Abstractions
{
    public class DataRequest<T> : IRequest<T> where T : class, new()
    {
        public CommandOption Command { get; set; }
        public T Model { get; set; }

        public IParameters Parameters { get; set; }
    }
}
