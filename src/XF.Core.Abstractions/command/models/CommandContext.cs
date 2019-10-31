using System;
using System.Collections.Generic;
using System.Text;

namespace XF.CQRS.Abstractions
{
    public class CommandContext<T> : ICommandContext<T> where T : class, new()
    {
        public ICommandRequest<T> Request { get; set; }
        public ICommandResponse<T> Response { get; set; }
        public DateTime Tds { get; set; }

        public CommandContext()
        {
            Tds = DateTime.Now;
        }
    }
}
