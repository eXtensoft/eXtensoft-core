using System;
using System.Collections.Generic;
using System.Text;
using XF.Api.Abstractions;

namespace XF.CQRS.Abstractions
{
    public class QueryContext<T> : IQueryContext<T> where T : class, new()
    {
        public IQueryRequest Request { get; set; }
        public IQueryResponse<T> Response { get; set; }
        public long Begin { get; set; }
        public long End { get; set; }
    }
}
