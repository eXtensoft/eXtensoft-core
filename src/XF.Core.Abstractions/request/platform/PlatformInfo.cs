using System;
using System.Collections.Generic;
using System.Text;
using XF.Core.Data;

namespace XF.Api.Abstractions
{
    public class PlatformInfo
    {
        public string Host { get; set; }
        public string Stage { get; set; } = "development";
        public string Realm { get; set; } = "site"; // site/ content/api/auth
        public string subdomain { get; set; }
        public string Domain { get; set; }
        public string TLD { get; set; }
        public string Url { get; set; }
        public string QueryString { get; set; }

        public TenantInfo Tenant { get; set; } = new TenantInfo();
        public List<string> Tokens { get; set; }
        public string RewrittenUrl { get; set; }
        public Waypoint Waypoint { get; set; }
        public Slug NavPath { get; set; }
    }
}
