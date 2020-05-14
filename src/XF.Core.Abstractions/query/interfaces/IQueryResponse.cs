using XF.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace XF.CQRS.Abstractions
{
    public interface IQueryResponse<T> where T : class, new()
    {
        HttpStatusCode Code { get; set; }
        string Message { get; set; }
        bool IsOkay { get; set; }
        Page<T> Page { get; set; }
    }
}
