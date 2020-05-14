using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using XF.Api.Abstractions;

namespace XF.Data.MongoDB.Instrumentation
{
    public static class ClassMapRegistrar
    {
        public static void Register()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(ApiRequestInfo)))
            {
                BsonClassMap.RegisterClassMap<ApiRequestInfo>(cm => {
                    cm.AutoMap();
                    cm.SetIgnoreExtraElements(true);
                    cm.MapIdProperty(c => c.Id);
                    cm.MapIdMember(c => c.Id)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId))
                    .SetIdGenerator(StringObjectIdGenerator.Instance);
                });
            }
            if (!BsonClassMap.IsClassMapRegistered(typeof(RequestInfo)))
            {
                BsonClassMap.RegisterClassMap<RequestInfo>(cm => {
                    cm.AutoMap();
                    cm.SetIgnoreExtraElements(true);
                    cm.MapIdProperty(c => c.Id);
                    cm.MapIdMember(c => c.Id)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId))
                    .SetIdGenerator(StringObjectIdGenerator.Instance);
                });
            }
        }
    }
}
