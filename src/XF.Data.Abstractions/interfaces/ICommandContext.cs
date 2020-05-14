using XF.CQRS.Abstractions;

namespace XF.EventSource.Abstractions
{
    public interface ICommandContext<T> where T : class, new()
    {
        ICommandRequest<T> Request { get; set; }
        ICommandResponse<T> Response { get; set; }
    }
}
