using XF.CQRS.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Data.Abstractions
{
    public class ApiQueryService<T> : IQueryService<T> where T : class, new()
    {
        IQueryContext<T> IQueryService<T>.Execute(IQueryContext<T> context)
        {
            throw new NotImplementedException();
        }
    }
}
