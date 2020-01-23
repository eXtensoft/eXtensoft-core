using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Rest.Abstractions
{
    public class MessageContext<T> : IMessageContext<T> where T : class, new()
    {
        public IRequest<T> Request { get; set; }
        public IResponse<T> Response { get; set; }
        public long Begin { get; set; }
        public long End { get; set; }
    }
}
