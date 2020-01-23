using System;
using System.Collections.Generic;
using System.Text;
using XF.Core.Abstractions;
using XF.Rest.Abstractions;

namespace XF.Rest.Abstractions
{
    public static class RestExtensions
    {
        public static IResponse<T> Delete<T>(this IDataService<T> service, IParameters parameters) where T : class, new()
        {
            IMessageContext<T> context = new MessageContext<T>().Delete(parameters);
            return service.Delete(context).Response;
        }
        public static IResponse<T> Get<T>(this IDataService<T> service, IParameters parameters) where T : class, new()
        {
            IMessageContext<T> context = new MessageContext<T>().Get(parameters);
            return service.Get(context).Response;
        }

        public static IResponse<T> Post<T>(this IDataService<T> service, T model) where T : class, new()
        {
            IMessageContext<T> context = new MessageContext<T>().Post(model);
            return service.Post(context).Response;
        }

        public static IResponse<T> Put<T>(this IDataService<T> service, T model, IParameters parameters) where T : class, new()
        {
            IMessageContext<T> context = new MessageContext<T>().Put(model,parameters);
            return service.Put(context).Response;
        }

    }
}
