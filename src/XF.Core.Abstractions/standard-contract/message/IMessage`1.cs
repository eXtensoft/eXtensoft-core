using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Rest.Abstractions
{
    public interface Message<T> where T : class, new()
    {
        IEnumerable<IProperty> Context { get; set; }
        IRequest<T> Request { get; set; }
        IResponse<T> Response { get; set; }
    }
}
