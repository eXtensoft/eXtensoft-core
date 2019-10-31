using XF.CQRS.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace XF.EventSource.Abstractions
{
    public interface ICommandContext<T> where T : class, new()
    {
        ICommandRequest<T> Request { get; set; }
        ICommandResponse<T> Response { get; set; }
        DateTime Tds { get; set; }
    }
}
