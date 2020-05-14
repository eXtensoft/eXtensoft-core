using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using XF.Data.Abstractions;

namespace XF.Data.MongoDB
{
    public abstract class MongoDBProvider
    {
        protected bool IsInitialized { get; set; } = false;
        protected MongoClient Client { get; set; }
        protected IMongoDatabase Database { get; set; }
        protected IConnectionStringProvider ConnectionStringProvider { get; set; }
        protected string DatabaseName { get; set; }
        protected abstract string ConnectionKey { get; }
        protected ILogger Logger { get; set; }
        protected bool InitializeMongoDB()
        {
            var connectionstring = ConnectionStringProvider.Get(ConnectionKey);
            if (!String.IsNullOrWhiteSpace(connectionstring))
            {
                try
                {
                    var parts = connectionstring.Split(new char[] { ';','|' });
                    Client = new MongoClient(parts[0]);
                    if (parts.Length >= 2)
                    {
                        DatabaseName = parts[1];
                        Database = Client.GetDatabase(DatabaseName);
                        IsInitialized = true;
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex, "MongoDB initialization error");
                }
            }
            else
            {
                Logger.LogError("not connection string");
            }
            return IsInitialized;
        }

    }
}
