using System;
using System.Collections.Generic;
using System.Text;

namespace XF.EventSource.Abstractions
{
    public interface ICommandEvent
    {
        string Sort { get; set; }
        string Source { get; set; }
        DateTime Tds { get; set; }
        string ModelId { get; set; }
        string ContentType { get; set; }
        string Schema { get; set; }
        string Command { get; set; }
        string Payload { get; set; }
    }
}
