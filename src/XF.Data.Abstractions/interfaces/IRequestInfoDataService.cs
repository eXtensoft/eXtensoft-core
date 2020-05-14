using System;
using System.Collections.Generic;
using System.Text;
using XF.Core.Abstractions;
using XF.Rest.Abstractions;

namespace XF.Api.Abstractions
{
    public interface IRequestInfoDataService
    {
        void Post(IRequestInfo model);
        IResponse<Page<RequestInfo>> Get(int limit, int offset, string marker);
    }
}
