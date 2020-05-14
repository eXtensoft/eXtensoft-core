using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace XF.Core.Abstractions
{
    public static class InstrumentationExtensions
    {
        public static DateTime ToDateTime(this long ticks)
        {
            var floor = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            return floor.AddSeconds((double)ticks).ToUniversalTime();
        }
        private static IEnumerable<Exception> Flatten(this Exception ex)
        {
            var innerException = ex;
            do
            {
                yield return innerException;
                innerException = innerException.InnerException;
            } while (innerException != null);
        }

        public static string Unwind(this Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in ex.Flatten())
            {
                sb.AppendLine(item.Message);
            }
            return sb.ToString();
        }


    }
}
