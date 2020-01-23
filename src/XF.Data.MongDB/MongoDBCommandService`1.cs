using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using XF.Api.Abstractions;
using XF.Core.Abstractions;
using XF.CQRS.Abstractions;
using XF.Rest.Abstractions;

namespace XF.Data.MongoDB
{
    public abstract class MongoDBCommandService<T> : MongoDBProvider, ICommandService<T> where T : class, new()
    {
        private string _CollectionName;
        protected virtual string CollectionName
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_CollectionName))
                {
                    _CollectionName = typeof(T).Name.ToLower();
                }
                return _CollectionName;
            }
            set { _CollectionName = value; }
        }
        protected IMongoCollection<T> Collection { get; set; }

        protected IApiRequestInfo RequestInfo { get; private set; }

        protected virtual bool Initialize()
        {
            bool b = InitializeMongoDB();
            if (b)
            {
                Collection = Database.GetCollection<T>(CollectionName);
            }

            return b;
        }
        ICommandContext<T> ICommandService<T>.Delete(ICommandContext<T> context)
        {
            context.Response = Delete(context.Request);
            return context;
        }

        ICommandContext<T> ICommandService<T>.Post(ICommandContext<T> context)
        {
            context.Response = Post(context.Request);
            return context;
        }

        ICommandContext<T> ICommandService<T>.Put(ICommandContext<T> context)
        {
            context.Response = Put(context.Request);
            return context;
        }

        protected virtual ICommandResponse<T> Delete(ICommandRequest<T> context)
        {
            var response = new CommandResponse<T>().Default(false);
            if (context.Parameters != null &&
                context.Parameters.TryGetValue<string>("Id", out string id))
            {
                try
                {
                    var filter = Builders<T>.Filter.Eq("Id", id);
                    var result = Collection.DeleteOne(filter);
                    response.Affected = (int)result.DeletedCount;
                    response.HttpStatus = HttpStatusCode.OK;
                }
                catch (Exception ex)
                {
                    OnException<T>(response, HttpVerb.DELETE, ex, context.Parameters, null);
                }
            }
            else
            {

            }

            return response;
        }
        protected virtual ICommandResponse<T> Post(ICommandRequest<T> context)
        {
            var response = new CommandResponse<T>().Default();
            try
            {
                Collection.InsertOne(context.Model);
                response.Model = context.Model;
            }
            catch (Exception ex)
            {
                OnException<T>(response, HttpVerb.POST, ex, null, context.Model);
            }
            
            return response;
        }



        protected virtual ICommandResponse<T> Put(ICommandRequest<T> context)
        {
            var response = new CommandResponse<T>().Default();

            if (context.Model != null && context.Model.TryGetId<T>(out string modelId))
            {
                var filter = Builders<T>.Filter.Eq("Id", modelId);
                try
                {
                    var result = Collection.ReplaceOne(filter, response.Model);
                    var replaced = result.ModifiedCount;
                    if (replaced != 1)
                    {
                        response.HttpStatus = HttpStatusCode.Conflict;
                        response.Message = "not modified";
                    }
                }
                catch (Exception ex)
                {
                    response.HttpStatus = HttpStatusCode.Conflict;
                    response.Message = ex.Message;
                }

            }
            else if((context.Parameters != null && 
                context.Parameters.TryGetValue<string>("Id", out string parameterId)))
            {

            }
            return response;
        }

        protected virtual void OnException<T>(CommandResponse<T> response,
            HttpVerb httpVerb,
            Exception ex,
            IParameters parameters,
            T model) where T : class, new()
        {
            response.OnException(RequestInfo, httpVerb, ex, parameters, model);
        }

    }
}
