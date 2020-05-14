using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace XF.Core.Abstractions
{
    public class Parameters : List<Parameter>, IParameters
    {
        public void Add(string key, object parameterValue)
        {
            this.Add(new Parameter() { Key = key, Value = parameterValue });
        }

        public bool ContainsKey(string key)
        {
            return Find(x => x.Key.Equals(key, StringComparison.OrdinalIgnoreCase)) != null;
        }

        public string GetStrategyKey()
        {
            return HasStrategy() ? Find(x=>x.Key.Equals("strategy")).Value.ToString() : string.Empty;
        }

        public T GetValue<T>(string key)
        {
            T t = default(T);
            bool b = false;
            for (int i = 0; !b && i < this.Count; i++)
            {
                if (this[i].Key.Equals(key, StringComparison.OrdinalIgnoreCase))
                {
                    var item = this[i];
                    try
                    {
                        t = (T)item.Value;
                    }
                    catch (Exception ex)
                    {

                    }
                    b = true;
                }
            }
            return t;
        }

        public bool HasStrategy()
        {
            return ContainsKey("strategy");
        }

        public bool TryGetValue<T>(string key, out T t)
        {
            t = default(T);
            bool b = false;
            for (int i = 0;!b && i < this.Count; i++)
            {
                if (this[i].Key.Equals(key,StringComparison.OrdinalIgnoreCase))
                {
                    var item = this[i];
                    try
                    {
                        t = (T)item.Value;                        
                    }
                    catch (Exception ex)
                    {

                    }
                    b = true;
                }
            }
            return b;
        }




        public static Parameters Empty = new Parameters();
        public static Parameters New(string key, object value)
        {
            Parameters parameters = new Parameters();
            parameters.Add(key, value);
            return parameters;
        }
        public static Parameters Strategy(string key, object value)
        {
            var parameters = New(key, value);
            parameters.Add("strategy", key);
            return parameters;
        }

        public T GetStrategyValue<T>()
        {
            T t = default(T);
            var key = this.Find(x => x.Key.Equals("strategy"));
            if (key != null)
            {
                var found = this.Find(x => x.Key.Equals(key.Value.ToString()));
                if (found != null)
                {
                    try
                    {
                        t = (T)found.Value;
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            return t;
        }

        IEnumerator<IParameter> IEnumerable<IParameter>.GetEnumerator()
        {
            foreach (var item in this)
            {
                yield return item;
            }
        }
    }
}
