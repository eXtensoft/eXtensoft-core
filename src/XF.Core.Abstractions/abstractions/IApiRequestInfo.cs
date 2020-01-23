using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Api.Abstractions
{
    public interface IApiRequestInfo
    {
        string Prefix { get; set; }
        string Id { get; set; }
        string CorrelationId { get; set; }
        string AuthId { get; set; }
        string App { get; set; }
        string Machine { get; set; }
        string Stage { get; set; }
        DateTimeOffset Begin { get; set; }
        DateTimeOffset End { get; set; }
        double Elapsed { get; set; }
        string Host { get; set; }
        string Scheme { get; set; }
        string Path { get; set; }
        string QueryString { get; set; }
        string Controller { get; set; }
        string Method { get; set; }
        string HttpVerb { get; set; }
        int HttpCode { get; set; }
        string[] Headers { get; set; }
        List<Datapoint> Request { get; set; }
        List<Datapoint> Response { get; set; }
    }
}
