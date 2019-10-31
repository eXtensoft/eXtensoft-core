using System;
using System.Collections.Generic;
using System.Text;

namespace XF.CQRS.Abstractions
{
    public interface IEventSourceService<T> : ICommandService<T> where T : class, new()
    {
    }
}
