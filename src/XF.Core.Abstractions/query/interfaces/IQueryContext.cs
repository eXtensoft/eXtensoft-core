using System;
using System.Collections.Generic;
using System.Text;

namespace XF.CQRS.Abstractions
{
    public interface IQueryContext<T> where T : class, new()
    {
        IQueryRequest Request { get; set; }
        IQueryResponse<T> Response { get; set; } 
    }
}
