using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Core.Data
{
    public class Content
    {
        public ContentPresenter Presenter { get; set; }
        public List<ContentItem> Items { get; set; }
    }
}
