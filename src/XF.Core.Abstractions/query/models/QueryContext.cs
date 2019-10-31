using System;
using System.Collections.Generic;
using System.Text;

namespace XF.CQRS.Abstractions
{
    public class QueryContext<T> : IQueryContext<T> where T : class, new()
    {
        public IQueryRequest Request { get; set; }
        public IQueryResponse<T> Response { get; set; }
        public DateTime Tds { get; set; } = DateTime.Now;
    }
}
