using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Core.Abstractions
{
    public class Parameter : IParameter
    {
        public string Key { get; set; }
        public object Value { get; set; }
    }
}
