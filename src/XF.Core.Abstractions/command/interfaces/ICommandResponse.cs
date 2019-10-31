using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace XF.CQRS.Abstractions
{
    public interface ICommandResponse<T> where T : class, new()
    {
        HttpStatusCode Code { get; set; }
        string Message { get; set; }
        bool IsOkay { get; set; }
        T Model { get; set; }
    }
}
