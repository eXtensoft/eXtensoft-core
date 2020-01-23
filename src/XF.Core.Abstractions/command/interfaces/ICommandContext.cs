namespace XF.CQRS.Abstractions
{
    public interface ICommandContext<T> where T : class, new()
    {
        ICommandRequest<T> Request { get; set; }
        ICommandResponse<T> Response { get; set; }
        long Begin { get; set; }
        long End { get; set; }
    }
}
