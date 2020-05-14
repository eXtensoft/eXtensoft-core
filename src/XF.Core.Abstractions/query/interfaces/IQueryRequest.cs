using System;
using System.Collections.Generic;
using System.Text;

namespace XF.CQRS.Abstractions
{
    public interface IQueryRequest
    {
        List<QueryValuePair> Parameters { get; set; }
        int PageIndex { get; set; }
        int PageSize { get; set; }
        string Identity { get; set; }
    }
}
