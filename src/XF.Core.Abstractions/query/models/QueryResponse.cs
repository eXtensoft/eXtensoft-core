using XF.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace XF.CQRS.Abstractions
{
    public class QueryResponse<T> : IQueryResponse<T> where T : class, new()
    {
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }
        public bool IsOkay { get; set; }
        public Page<T> Page { get; set; }
        
    }
}
