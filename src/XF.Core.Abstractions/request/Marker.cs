using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Api.Abstractions
{
    public class Marker
    {
        public string Key { get; set; }
        public long Start { get; set; }
        public long Stop { get; set; }
        public double Elapsed { get; set; }
    }
}
