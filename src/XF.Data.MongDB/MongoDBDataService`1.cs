using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using XF.Api.Abstractions;
using XF.Core.Abstractions;
using XF.Data.Abstractions;
using XF.Rest.Abstractions;

namespace XF.Data.MongoDB
{
    public abstract class MongoDBDataService<T> : MongoDBProvider, IDataService<T> where T : class, new()
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

        protected IRequestInfo RequestInfo { get; private set; }

        //public MongoDBDataService(IConnectionStringProvider connectionStringProvider, 
        //    IRequestInfo requestInfo)
        //{
        //    ConnectionStringProvider = connectionStringProvider ?? throw new ArgumentNullException(nameof(connectionStringProvider));
        //    RequestInfo = requestInfo ?? throw new ArgumentNullException(nameof(requestInfo));
        //}

        public MongoDBDataService(IConnectionStringProvider connectionStringProvider)
        {
            ConnectionStringProvider = connectionStringProvider ?? throw new ArgumentNullException(nameof(connectionStringProvider));
        }


        protected virtual bool Initialize()
        {
            bool b = InitializeMongoDB();
            if (b)
            {
                Collection = Database.GetCollection<T>(CollectionName);
            }
            
            return b;
        }

        IMessageContext<T> IDataService<T>.Get(IMessageContext<T> message)
        {
            message.Begin = DateTime.Now.Ticks;
            message.Response = Get(message.Request.Parameters);
            message.End = DateTime.Now.Ticks;
            return message;
        }

        IMessageContext<T> IDataService<T>.Delete(IMessageContext<T> message)
        {
            message.Begin = DateTime.Now.Ticks;
            message.Response = Delete(message.Request.Parameters);
            message.End = DateTime.Now.Ticks;
            return message;
        }

        IMessageContext<T> IDataService<T>.Post(IMessageContext<T> message)
        {
            message.Begin = DateTime.Now.Ticks;
            message.Response = Post(message.Request.Model);
            message.End = DateTime.Now.Ticks;
            return message;
        }

        IMessageContext<T> IDataService<T>.Put(IMessageContext<T> message)
        {
            message.Begin = DateTime.Now.Ticks;
            message.Response = Put(message.Request.Model, message.Request.Parameters);
            message.End = DateTime.Now.Ticks;
            return message;
        }

        async Task<IMessageContext<T>> IDataService<T>.GetAsync(IMessageContext<T> message)
        {
            message.Begin = DateTime.Now.Ticks;
            message.Response = await GetAsync(message.Request.Parameters);
            message.End = DateTime.Now.Ticks; 
            return message;
        }

        async Task<IMessageContext<T>> IDataService<T>.DeleteAsync(IMessageContext<T> message)
        {
            message.Begin = DateTime.Now.Ticks;
            message.Response = await DeleteAsync(message.Request.Parameters);
            message.End = DateTime.Now.Ticks;
            return message;
        }

        async Task<IMessageContext<T>> IDataService<T>.PostAsync(IMessageContext<T> message)
        {
            message.Begin = DateTime.Now.Ticks;
            message.Response = await PostAsync(message.Request.Model);
            message.End = DateTime.Now.Ticks;
            return message;
        }

        async Task<IMessageContext<T>> IDataService<T>.PutAsync(IMessageContext<T> message)
        {
            message.Begin = DateTime.Now.Ticks;
            message.Response = await PutAsync(message.Request.Model, message.Request.Parameters);
            message.End = DateTime.Now.Ticks;
            return message;
        }


        protected virtual IResponse<T> Delete(IParameters parameters)
        {
            var response = new DataResponse<T>().Default();
            if (parameters.TryGetValue<string>("Id", out string id))
            {
                try
                {
                    var filter = Builders<T>.Filter.Eq("Id", id);
                    var result = Collection.DeleteOne(filter);
                    response.Status.Affected = (int)result.DeletedCount;
                }
                catch (Exception ex)
                {
                    OnException(response, HttpVerb.DELETE, ex, parameters, null);
                }
            }
            return response;
        }

        protected virtual async Task<IResponse<T>> DeleteAsync(IParameters parameters)
        {
            var response = new DataResponse<T>().Default();
            if (parameters.TryGetValue<string>("Id", out string id))
            {
                try
                {
                    var filter = Builders<T>.Filter.Eq("Id", id);
                    var result = await Collection.DeleteOneAsync(filter);
                    response.Status.Affected = (int)result.DeletedCount;
                }
                catch (Exception ex)
                {
                    OnException(response, HttpVerb.DELETE, ex, parameters, null);
                }
            }
            return response;
        }
        protected virtual IResponse<T> Get(IParameters parameters)
        {
            var response = new DataResponse<T>().Default();
            FilterDefinition<T> filter;
            //if (TryBuildGetFilter(parameters, out filter) || parameters.TryBuildFilter<T>(out filter))
            if ( parameters.TryBuildFilter<T>(out filter) || TryBuildGetFilter(parameters, out filter))
            {
                try
                {
                    response.Items = Collection.Find<T>(filter).ToList();
                    if (response.Items.Count == 0)
                    {
                        response.Status.HttpStatus = System.Net.HttpStatusCode.NotFound;
                        response.IsOkay = false;
                    }
                }
                catch (Exception ex)
                {
                    OnException(response, HttpVerb.GET, ex, parameters, null);
                }
            }
            return response;
        }

        protected virtual bool TryBuildGetFilter(IParameters parameters, 
            out FilterDefinition<T> filter)
        {
            filter = Builders<T>.Filter.Empty;
            return false;
        }

        protected virtual async Task<IResponse<T>> GetAsync(IParameters parameters)
        {
            var response = new DataResponse<T>().Default();
            if (parameters != null && parameters.TryGetValue<string>("Id", out string id))
            {
                try
                {
                    var filter = Builders<T>.Filter.Eq("Id", id);
                    var result = await Collection.FindAsync<T>(filter);
                    response.Items = result.ToList();
                }
                catch (Exception ex)
                {
                    OnException(response, HttpVerb.GET, ex, parameters, null);
                }
            }
            else
            {
                try
                {
                    var filter = Builders<T>.Filter.Empty;
                    var result = await Collection.FindAsync<T>(filter);
                    response.Items = result.ToList();
                }
                catch (Exception ex)
                {
                    OnException(response, HttpVerb.GET, ex, parameters, null);
                }

            }
            return response;
        }
        protected virtual IResponse<T> Post(T model)
        {
            var response = new DataResponse<T>().Default();
            try
            {
                Collection.InsertOne(model);
                response.Model = model;
            }
            catch (Exception ex)
            {
                OnException(response, HttpVerb.POST, ex, null, model);
            }

            return response;
        }
        protected virtual async Task<IResponse<T>> PostAsync(T model)
        {
            var response = new DataResponse<T>().Default();
            try
            {
                await Collection.InsertOneAsync(model);
                response.Model = model;
            }
            catch (Exception ex)
            {
                OnException(response, HttpVerb.POST, ex, null, model);
            }

            return response;
        }
        protected virtual IResponse<T> Put(T model, IParameters parameters)
        {
            var response = new DataResponse<T>().Default();
            if (model != null && 
                model.TryGetId<T>(out string id))
            {
                try
                {
                    var filter = Builders<T>.Filter.Eq("Id", id);
                    var result = Collection.ReplaceOne(filter,model);
                    response.Status.Affected = (int)result.ModifiedCount;
                }
                catch (Exception ex)
                {
                    OnException(response, HttpVerb.PUT, ex, parameters, model);
                }

            }
            else if(parameters != null && 
                parameters.TryGetValue<string>("Id", out string paramId))
            {
                try
                {
                    var filter = Builders<T>.Filter.Eq("Id", paramId);
                    var result = Collection.ReplaceOne(filter, model);
                    response.Status.Affected = (int)result.ModifiedCount;
                }
                catch (Exception ex)
                {
                    OnException(response, HttpVerb.PUT, ex, parameters, model);
                }
            }
            return response;
           
        }

        protected virtual async Task<IResponse<T>> PutAsync(T model, IParameters parameters)
        {
            var response = new DataResponse<T>().Default();
            if (model != null &&
                model.TryGetId<T>(out string id))
            {
                try
                {
                    var filter = Builders<T>.Filter.Eq("Id", id);
                    var result = await Collection.ReplaceOneAsync(filter, model);
                    response.Status.Affected = (int)result.ModifiedCount;
                }
                catch (Exception ex)
                {
                    OnException(response, HttpVerb.PUT, ex, parameters, model);
                }

            }
            else if (parameters != null &&
                parameters.TryGetValue<string>("Id", out string paramId))
            {
                try
                {
                    var filter = Builders<T>.Filter.Eq("Id", paramId);
                    var result = await Collection.ReplaceOneAsync(filter, model);
                    response.Status.Affected = (int)result.ModifiedCount;
                }
                catch (Exception ex)
                {
                    OnException(response, HttpVerb.PUT, ex, parameters, model);
                }
            }
            return response;
        }

        protected virtual void OnException(DataResponse<T> response, 
            HttpVerb httpVerb,
            Exception ex, 
            IParameters parameters, 
            T model)
        {
            response.OnException(RequestInfo, httpVerb, ex, parameters, model);
        }

    }
}
