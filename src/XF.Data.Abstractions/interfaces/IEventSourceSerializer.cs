using XF.CQRS.Abstractions;
using XF.Data.Abstractions;
using XF.EventSource.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace XF.CQRS.Abstractions
{
    public interface IEventSourceSerializer
    {
        ISerializer Serializer { get; set; }
        ICommandEvent Serialize<T>(ICommandRequest<T> contextRequest) where T : class, new();

        ICommandRequest<T> Deserialize<T>(ICommandEvent commandEvent) where T : class, new();
    }
}
