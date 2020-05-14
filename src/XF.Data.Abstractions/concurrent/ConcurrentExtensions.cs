using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace XF.Data.Concurrent
{
    public static class ConcurrentExtensions
    {
        public static IEnumerable<T> ToModels<T>(this IEnumerable<Task<Data<T>>> enumerable) where T : class, new()
        {
            return (from item in enumerable 
                    where String.IsNullOrEmpty(item.Result.Message) 
                    select item.Result.Model).ToList();
        }
    }
}
