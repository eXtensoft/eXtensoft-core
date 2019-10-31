using System;
using System.Collections.Generic;
using System.Text;

namespace XF.CQRS.Abstractions
{
    public interface ICommandContext<T> where T : class, new()
    {
        ICommandRequest<T> Request { get; set; }
        ICommandResponse<T> Response { get; set; }
        DateTime Tds { get; set; }
    }
}
