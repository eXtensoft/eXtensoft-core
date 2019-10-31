using System;
using System.Collections.Generic;
using System.Text;

namespace XF.CQRS.Abstractions
{
    public interface ICommandRequest<T> where T : class, new()
    {
        CommandOption Command { get; set; }
        T Model { get; set; }
    }
}
