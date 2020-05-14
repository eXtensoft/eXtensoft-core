using XF.EventSource.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace XF.EventSource.Abstractions
{
    public class CommandEvent : ICommandEvent
    {
        public string Sort { get; set; }
        public string Source { get; set; }
        public DateTime Tds { get; set; }
        public string ModelId { get; set; }
        public string ContentType { get; set; }
        public string Schema { get; set; }
        public string Command { get; set; }
        public string Payload { get; set; }
    }
}
