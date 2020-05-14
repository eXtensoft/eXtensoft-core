using XF.CQRS.Abstractions;
using XF.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace XF.EventSource.Abstractions
{
    public class EventSourceSerializer : IEventSourceSerializer
    {
        public ISerializer Serializer { get; set; }

        ICommandRequest<T> IEventSourceSerializer.Deserialize<T>(ICommandEvent commandEvent)
        {
            throw new NotImplementedException();
        }

        ICommandEvent IEventSourceSerializer.Serialize<T>(ICommandRequest<T> contextRequest)  
        {
            ICommandEvent data = new CommandEvent()
            {
                Command = contextRequest.Command.ToString(),
                ContentType = Serializer.ContentType,
                ModelId = "",// contextRequest.Model.Id,
                Source = "source",
                Schema = "content-item",
                Sort = "1",
                Payload = Serializer.Serialize<T>(contextRequest.Model)
            };

            return data;
        }
    }
}
