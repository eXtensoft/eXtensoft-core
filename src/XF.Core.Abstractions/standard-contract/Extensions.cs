using System;
using System.Collections.Generic;
using System.Text;
using XF.Core.Abstractions;

namespace XF.Rest.Abstractions
{
    public static class Extensions
    {
        public static IMessageContext<T> Delete<T>(this IMessageContext<T> context,
            IParameters parameters) where T : class, new()
        {
            context.Request = new DataRequest<T>()
            {
                Parameters = parameters,
                Command = CommandOption.DELETE
            };
            return context;
        }

        public static IMessageContext<T> Get<T>(this IMessageContext<T> context,
            IParameters parameters) where T : class, new()
        {
            context.Request = new DataRequest<T>()
            {
                Parameters = parameters,
                Command = CommandOption.GET
            };
            return context;
        }

        public static IMessageContext<T> Post<T>(this IMessageContext<T> context, 
            T model) where T : class, new()
        {
            context.Request = new DataRequest<T>() 
            { 
                Model = model, 
                Command = CommandOption.POST 
            };
            return context;
        }

        public static IMessageContext<T> Put<T>(this IMessageContext<T> context, 
            T model, 
            IParameters parameters) where T : class, new()
        {
            context.Request = new DataRequest<T>() 
            { 
                Model = model, 
                Parameters = parameters, 
                Command = CommandOption.PUT 
            };
            return context;
        }

    }
}
