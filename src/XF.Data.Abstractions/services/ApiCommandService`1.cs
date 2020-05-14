using XF.CQRS.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Data.Abstractions
{
    public class ApiCommandService<T> : ICommandService<T> where T : class, new()
    {
        ICommandContext<T> ICommandService<T>.Delete(ICommandContext<T> context)
        {
            throw new NotImplementedException();
        }

        ICommandContext<T> ICommandService<T>.Post(ICommandContext<T> context)
        {
            throw new NotImplementedException();
        }

        ICommandContext<T> ICommandService<T>.Put(ICommandContext<T> context)
        {
            throw new NotImplementedException();
        }
    }
}
