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
    public class ApiRequestInfoDataService : MongoDBDataService<ApiRequestInfo>, IApiRequestInfoDataService
    {
        protected override string ConnectionKey => "instrumentation";

        static ApiRequestInfoDataService()
        {
            ClassMapRegistrar.Register();
        }


        public ApiRequestInfoDataService(ILoggerFactory loggerFactory,
            IConnectionStringProvider connectionStringProvider)
        {
            Logger = loggerFactory.CreateLogger<ApiRequestInfoDataService>();
            ConnectionStringProvider = connectionStringProvider ?? throw new ArgumentNullException(nameof(connectionStringProvider));
            Initialize();
        }

        void IApiRequestInfoDataService.Post(IApiRequestInfo model)
        {
            this.Post(model as ApiRequestInfo);
        }

        IResponse<Page<ApiRequestInfo>> IApiRequestInfoDataService.Get(int limit, int offset, string marker)
        {
            throw new NotImplementedException();
        }
    }
}
