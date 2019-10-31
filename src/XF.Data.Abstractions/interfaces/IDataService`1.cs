using System;
using System.Collections.Generic;
using System.Text;

namespace XF.CQRS.Abstractions
{
    public interface IDataService<T> : ICommandService<T> where T : class, new()
    {
    }
}
