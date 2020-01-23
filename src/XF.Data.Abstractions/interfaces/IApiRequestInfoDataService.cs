using XF.Core.Abstractions;
using XF.Rest.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Api.Abstractions
{
    public interface IApiRequestInfoDataService
    {
        void Post(IApiRequestInfo model);
        IResponse<Page<ApiRequestInfo>> Get(int limit, int offset, string marker);
    }
}
