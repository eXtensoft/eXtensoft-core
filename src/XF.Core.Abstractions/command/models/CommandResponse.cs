using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace XF.CQRS.Abstractions
{
    public class CommandResponse<T> : ICommandResponse<T> where T : class, new()
    {
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }
        public bool IsOkay { get; set; }
        public T Model { get; set; }
    }
}
