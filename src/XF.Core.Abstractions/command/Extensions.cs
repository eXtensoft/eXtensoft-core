using System;
using System.Collections.Generic;
using System.Text;
using XF.Core.Abstractions;

namespace XF.CQRS.Abstractions
{
    public static class Extensions
    {

        public static ICommandContext<T> Post<T>(this ICommandContext<T> context, T model) where T : class, new()
        {
            context.Request = new CommandRequest<T>() { Model = model, Command = CommandOption.POST };
            return context;
        }

        public static ICommandContext<T> Put<T>(this ICommandContext<T> context, T model) where T : class, new()
        {
            context.Request = new CommandRequest<T>() { Model = model, Command = CommandOption.PUT };
            return context;
        }

        public static ICommandContext<T> Delete<T>(this ICommandContext<T> context, string id) where T : class, new()
        {

            context.Request = new CommandRequest<T>() { Model = new T(), Command = CommandOption.DELETE };
            return context;
        }
    }
}
