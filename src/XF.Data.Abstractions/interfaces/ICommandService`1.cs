using System;
using System.Collections.Generic;
using System.Text;

namespace XF.CQRS.Abstractions
{
    public interface ICommandService<T> where T : class, new()
    {
        ICommandContext<T> Post(ICommandContext<T> context);
        ICommandContext<T> Put(ICommandContext<T> context);
        ICommandContext<T> Delete(ICommandContext<T> context);

    }
}
