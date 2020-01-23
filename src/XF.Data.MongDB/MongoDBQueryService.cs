using System;
using System.Collections.Generic;
using System.Text;
using XF.CQRS.Abstractions;

namespace XF.Data.MongoDB
{
    public abstract class MongoDBQueryService<T> : MongoDBProvider, IQueryService<T> where T : class, new()
    {
        

        protected virtual bool Initialize()
        {
            return InitializeMongoDB();
        }

        IQueryContext<T> IQueryService<T>.Execute(IQueryContext<T> context)
        {
            return Execute(context);
        }
        protected abstract IQueryContext<T> Execute(IQueryContext<T> context);
    }
}
