using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Rest.Abstractions
{
    public interface IProperty
    {
        string Name { get; set; }

        object Value { get; set; }
    }
}
