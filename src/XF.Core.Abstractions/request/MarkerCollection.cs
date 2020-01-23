using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace XF.Api.Abstractions
{
    public class MarkerCollection : KeyedCollection<string,Marker>
    {
        protected override string GetKeyForItem(Marker item)
        {
            return item.Key;
        }


    }
}
