namespace XF.CQRS.Abstractions
{
    public interface IQueryContext<T> where T : class, new()
    {
        IQueryRequest Request { get; set; }
        IQueryResponse<T> Response { get; set; }
        long Begin { get; set; }
        long End { get; set; }
    }
}
