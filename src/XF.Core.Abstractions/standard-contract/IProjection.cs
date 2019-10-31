using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Core.Abstractions
{
    public interface IProjection
    {
        IEnumerable<string> Data { get; set; }
    }
}
