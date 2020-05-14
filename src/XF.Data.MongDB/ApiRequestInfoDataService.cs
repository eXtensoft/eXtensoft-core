using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using XF.Api.Abstractions;
using XF.Core.Abstractions;
using XF.Data.Abstractions;
using XF.Data.MongoDB.Instrumentation;
using XF.Rest.Abstractions;

namespace XF.Data.MongoDB
{
    public class RequestInfoDataService : MongoDBDataService<RequestInfo>, IApiRequestInfoDataService, IRequestInfoDataService
    {
        protected override string ConnectionKey => "instrumentation";

        static RequestInfoDataService()
        {
            ClassMapRegistrar.Register();
        }


        public RequestInfoDataService(ILoggerFactory loggerFactory,
            IConnectionStringProvider connectionStringProvider):base(connectionStringProvider)
        {
            Logger = loggerFactory.CreateLogger<RequestInfoDataService>();
            Initialize();
        }

        void IApiRequestInfoDataService.Post(IApiRequestInfo model)
        {
            this.Post(model as RequestInfo);
        }

        IResponse<Page<ApiRequestInfo>> IApiRequestInfoDataService.Get(int limit, int offset, string marker)
        {
            throw new NotImplementedException();
        }

        void IRequestInfoDataService.Post(IRequestInfo model)
        {
            this.Post(model as RequestInfo);
        }

        IResponse<Page<RequestInfo>> IRequestInfoDataService.Get(int limit, int offset, string marker)
        {
            throw new NotImplementedException();
        }
    }
}
