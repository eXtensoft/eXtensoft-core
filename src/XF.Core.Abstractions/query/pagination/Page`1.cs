using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Core.Abstractions
{
    public class Page<T> where T : class, new()
    {
        public List<T> Items { get; set; }

        public int Index { get; set; }
        public int Size { get; set; }
        public int Total { get; set; }

        public QueryAggregation Aggs { get; set; }

        public List<PageIndex> Pagination { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"total:{Total}\tsize:{Size}\tindex:{Index}");
            sb.AppendLine();
            foreach (var item in Items)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
    }
}
