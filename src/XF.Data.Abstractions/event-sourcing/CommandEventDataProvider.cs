using XF.EventSource.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace XF.EventSource.Abstractions
{
    public abstract class CommandEventDataProvider : ICommandEventDataProvider
    {

        ICommandEvent ICommandEventDataProvider.Post(ICommandEvent commandEvent)
        {
            return Post(commandEvent);
        }

        public abstract ICommandEvent Post(ICommandEvent commandEvent);
    }
}
