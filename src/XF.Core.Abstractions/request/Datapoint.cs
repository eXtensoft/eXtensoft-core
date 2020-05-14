using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Api.Abstractions
{
    public class Datapoint
    {
        public string Key { get; set; }
        public string Groupname { get; set; }
        public string Datatype { get; set; }
        public object Value { get; set; }
    }
}
