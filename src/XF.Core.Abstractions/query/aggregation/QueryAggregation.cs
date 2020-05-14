using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Core.Abstractions
{
    public class QueryAggregation
    {
        public string Name { get; set; }
        public List<QueryAggregate> Aggregates { get; set; } = new List<QueryAggregate>();

    }
}
