using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Api.Abstractions
{
    public class RequestInfo : IRequestInfo
    {
        public string TrackingId { get; set; }
        public PlatformInfo Platform { get; set; } = new PlatformInfo();
        public string Prefix { get; set; } = "xf";
        public string Id { get; set; }
        public string CorrelationId { get; set; }
        public string AuthId { get; set; }
        public DateTimeOffset Begin { get; set; }
        public DateTimeOffset End { get; set; }
        public double Elapsed { get; set; }
        public string App { get; set; }
        public string Stage { get; set; }
        public string Machine { get; set; }
        public string Host { get; set; }
        public string Scheme { get; set; }
        public string Path { get; set; }
        public string RoutingPath { get; set; }
        public string QueryString { get; set; }
        public string HttpVerb { get; set; }
        public int HttpCode { get; set; }
        public string Controller { get; set; }
        public string Method { get; set; }
        public string[] Headers { get; set; }
        public List<Datapoint> Request { get; set; } = new List<Datapoint>();
        public List<Datapoint> Response { get; set; } = new List<Datapoint>();
        public MarkerCollection Markers { get; set; } = new MarkerCollection();
        public List<Datapoint> Data { get; set; } = new List<Datapoint>();
    }
}
