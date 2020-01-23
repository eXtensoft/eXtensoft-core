using XF.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace XF.Rest.Abstractions
{
    public interface IRequest<T> where T : class, new()
    {
        CommandOption Command { get; set; }

        T Model { get; set; }

        IParameters Parameters { get; set; }

    }
}
