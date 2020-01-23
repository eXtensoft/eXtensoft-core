using XF.Core.Abstractions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace XF.Rest.Abstractions
{
    public class DataResponse<T> : IResponse<T> where T : class, new()
    {
        private List<T> _Items = new List<T>();
        public List<T> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }

        public T Model
        {
            get { return _Items.Count > 0 ? _Items[0] : default(T); }
            set { _Items.Add(value); }
        }

        private bool _IsOkay = false;
        public bool IsOkay { get { return _IsOkay; } set { _IsOkay = value; } }

        private IStatus _Status = null;
        public IStatus Status { get { return _Status; } set { _Status = value; } }

        private int _Count = -1;
        public int Count { 
            get 
            { 
                return _Count > -1 ? _Count: Items.Count; 
            }
            set
            {
                _Count = value;
            }
        }

        private int _Elapsed = 0;
        public long Elapsed { get { return _Elapsed; } }

        private Page<T> _Page = null;
        public Page<T> Page
        {
            get
            {
                if (_Page == null)
                {
                    int total = Items.Count;
                    //_Page = new DataPage(total);
                }
                else if (_Page.Total == 0)
                {
                    _Page.Total = _Items.Count;
                }
                return _Page;
            }
            set { _Page = value; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_Items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)_Items).GetEnumerator();
        }

    }
}
