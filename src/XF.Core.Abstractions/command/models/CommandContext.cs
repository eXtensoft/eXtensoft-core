using System;

namespace XF.CQRS.Abstractions
{
    public class CommandContext<T> : ICommandContext<T> where T : class, new()
    {
        public ICommandRequest<T> Request { get; set; }
        public ICommandResponse<T> Response { get; set; }
        public long Begin { get; set; }
        public long End { get; set; }

        public CommandContext()
        {
            
        }
    }
}
