using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using XF.Core.Abstractions;

namespace XF.Rest.Abstractions
{
    public class ResponseStatus : IStatus
    {
        public HttpStatusCode HttpStatus { get; set; }

        public string ReturnCode { get; set; }

        public string Message { get; set; }

        public string SystemMessage {get; set;}

        public int Affected {get; set;}
    }
}
