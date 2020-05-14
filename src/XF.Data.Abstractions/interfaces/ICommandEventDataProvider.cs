using XF.EventSource.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace XF.EventSource.Abstractions
{
    public interface ICommandEventDataProvider
    {
        ICommandEvent Post(ICommandEvent commandEvent);
    }
}
