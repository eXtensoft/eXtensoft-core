using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

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
            throw new NotImplementedException();
        }

        public string GetStrategyKey()
        {
            throw new NotImplementedException();
        }

        public T GetValue<T>(string key)
        {
            throw new NotImplementedException();
        }

        public bool HasStrategy()
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue<T>(string key, out T t)
        {
            throw new NotImplementedException();
        }

        IEnumerator<IParameter> IEnumerable<IParameter>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public static Parameters Empty = new Parameters();

    }
}
