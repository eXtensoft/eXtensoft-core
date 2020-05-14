using XF.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Rest.Abstractions
{
    public interface IResponse<T> : IEnumerable<T> where T : class, new()
    {
        int Count { get; }

        long Elapsed { get; }

        T Model { get; }

        bool IsOkay { get; set; }

        IStatus Status { get; set; }

        Page<T> Page { get; set; }

    }
}
