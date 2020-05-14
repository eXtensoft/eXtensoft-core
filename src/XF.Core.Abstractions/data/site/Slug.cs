using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Core.Data
{
    public class Slug
    {
        public string Id { get; set; }
        public int Level { get; set; }
        public string Display { get; set; }
        public string Token { get; set; }
        public string Path { get; set; }
        public List<Slug> Slugs { get; set; }
    }
}
