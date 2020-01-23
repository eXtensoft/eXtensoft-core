using System.Collections.Generic;
using XF.Api.Abstractions;
using XF.Core.Abstractions;
using XF.Rest.Abstractions;

namespace XF.Data.Memory
{
    public class ApiRequestInfoDataService : IApiRequestInfoDataService
    {
        public List<ApiRequestInfo> Datastore { get; set; } = new List<ApiRequestInfo>();


        IResponse<Page<ApiRequestInfo>> IApiRequestInfoDataService.Get(int limit, int offset, string marker)
        {
            var response = new DataResponse<Page<ApiRequestInfo>>();
            Page<ApiRequestInfo> page = new Page<ApiRequestInfo>() { Size = limit, Index = offset };
            page.Items = Datastore;
            response.Items.Add(page);
            return response;
        }

        void IApiRequestInfoDataService.Post(IApiRequestInfo model)
        {
            Datastore.Add(model as ApiRequestInfo);
        }
    }
}
