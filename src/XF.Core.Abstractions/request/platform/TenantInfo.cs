using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Api.Abstractions
{
    public class TenantInfo
    {
        public string Id { get; set; } = "4497be4f-5485-44c5-9178-9762408ebc0e";
        public string Display { get; set; } = "Titan";
        public string Token { get; set; } = "titan";
        public List<Datapoint> Data { get; set; } = new List<Datapoint>();
    }
}
