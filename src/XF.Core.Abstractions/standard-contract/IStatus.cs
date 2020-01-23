using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace XF.Core.Abstractions
{
    public interface IStatus
    {
        HttpStatusCode HttpStatus { get; set; }

        string ReturnCode { get; set; }

        string Message { get; set; }

        string SystemMessage { get; set; }

        int Affected { get; set; }
    }
}
