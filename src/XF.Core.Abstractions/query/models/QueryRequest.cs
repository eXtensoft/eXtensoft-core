using System;
using System.Collections.Generic;
using System.Text;

namespace XF.CQRS.Abstractions
{
    public class QueryRequest : IQueryRequest
    {
        public List<QueryValuePair> Parameters { get; set; } = new List<QueryValuePair>();
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 20;
        public string Identity { get; set; }
    }
}
