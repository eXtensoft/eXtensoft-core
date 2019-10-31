using System;
using System.Collections.Generic;
using System.Text;

namespace XF.CQRS.Abstractions
{
    public class CommandRequest<T> : ICommandRequest<T> where T : class, new()
    {
        public CommandOption Command { get; set; }
        public T Model { get; set; }
    }
}
