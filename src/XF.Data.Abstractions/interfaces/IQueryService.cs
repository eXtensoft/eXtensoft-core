using System;
using System.Collections.Generic;
using System.Text;

namespace XF.CQRS.Abstractions
{
    public interface IQueryService<T> where T : class, new()
    {
        IQueryContext<T> Execute(IQueryContext<T> context);
    }
}
