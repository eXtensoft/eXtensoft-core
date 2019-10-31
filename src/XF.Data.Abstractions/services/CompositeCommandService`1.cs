using XF.CQRS.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Data.Abstractions
{
    public class CompositeCommandService<T> : ICommandService<T> where T : class, new()
    {

        ICommandService<T> EventSourceService { get; set; }
        ICommandService<T> DataService { get; set; }
        public CompositeCommandService(
            IEventSourceService<T> eventSourceService,
            IDataService<T> dataService)
        {
            EventSourceService = eventSourceService ?? throw new NullReferenceException(nameof(eventSourceService));
            DataService = dataService ?? throw new NullReferenceException(nameof(dataService));
        }

        public ICommandContext<T> Post(ICommandContext<T> context)
        {
            var ctx = EventSourceService.Post(context);
            return DataService.Post(ctx);
        }

        public ICommandContext<T> Put(ICommandContext<T> context)
        {
            var ctx = EventSourceService.Put(context);
            return DataService.Post(ctx);
        }

        public ICommandContext<T> Delete(ICommandContext<T> context)
        {
            var ctx = EventSourceService.Delete(context);
            return DataService.Post(context);
        }
    }
}
