using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XF.Caching.Abstractions;
using XF.Core.Abstractions;
using XF.Rest.Abstractions;

namespace XF.Caching
{
    public class ReadThroughCache<T> : IReadThroughCache<T> where T : class, new()
    {
        protected ICache<T> _Cache;
        protected IDataService<T> _DataService;
        
        public ReadThroughCache(ICache<T> cache, IDataService<T> dataService)
        {
            _Cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _DataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        bool IReadThroughCache<T>.TryGet(string key, out T value)
        {
            bool b = false;
            if (!_Cache.TryGet(key, out value))
            {
                var response = _DataService.Get(Parameters.New("Id", key));
                if (response.IsOkay)
                {
                    value = response.Model;
                    b = true;
                    _Cache.Set(key, value);
                }
            }
            else
            {
                b = true;
            }
            return b;
        }

        bool IReadThroughCache<T>.Invalidate(string key)
        {
            throw new NotImplementedException();
        }


        IMessageContext<T> IDataService<T>.Put(IMessageContext<T> message)
        {
            throw new NotImplementedException();
        }

        Task<IMessageContext<T>> IDataService<T>.PutAsync(IMessageContext<T> message)
        {
            throw new NotImplementedException();
        }

        IMessageContext<T> IDataService<T>.Delete(IMessageContext<T> message)
        {
            bool b = false;
            if (message.Request.Parameters.TryGetValue<string>("Id", out string key))
            {
                b = _Cache.Invalidate(key);
            }
            message.Response = new DataResponse<T>() { IsOkay = true, Count = b ? 1 : 0 };
            return message;
        }

        Task<IMessageContext<T>> IDataService<T>.DeleteAsync(IMessageContext<T> message)
        {
            bool b = false;
            if (message.Request.Parameters.TryGetValue<string>("Id", out string key))
            {
                b = _Cache.Invalidate(key);
            }
            message.Response = new DataResponse<T>() { IsOkay = true, Count = b ? 1 : 0 };
            return Task.FromResult(message);
        }

        IMessageContext<T> IDataService<T>.Get(IMessageContext<T> message)
        {
            
            if (message.Request.Parameters.TryGetValue<string>("Id", out string key))
            {
                if(!_Cache.TryGet(key,out T model))
                {
                    IResponse<T> response = _DataService.Get(message).Response;
                    if (response.IsOkay)
                    {
                        message.Response = new DataResponse<T>()
                        {
                            Model = response.Model,
                            IsOkay = true
                        };
                    }
                    else
                    {
                        message.Response = new DataResponse<T>() { IsOkay = false };
                    }
                }
                else
                {
                    message.Response = new DataResponse<T>() { Model = model };
                }
            }
            else
            {
                message.Response = new DataResponse<T>() { IsOkay = false };
            }
            return message;
        }

        Task<IMessageContext<T>> IDataService<T>.GetAsync(IMessageContext<T> message)
        {
            if (message.Request.Parameters.TryGetValue<string>("key", out string key))
            {
                if (!_Cache.TryGet(key, out T model))
                {
                    IResponse<T> response =  _DataService.GetAsync(message).Result.Response;
                    if (response.IsOkay)
                    {
                        message.Response = new DataResponse<T>()
                        {
                            Model = response.Model,
                            IsOkay = true
                        };
                    }
                    else
                    {
                        message.Response = new DataResponse<T>() { IsOkay = false };
                    }
                }
                else
                {
                    message.Response = new DataResponse<T>() { Model = model };
                }
            }
            else
            {
                message.Response = new DataResponse<T>() { IsOkay = false };
            }
            return Task.FromResult(message);
        }

        IMessageContext<T> IDataService<T>.Post(IMessageContext<T> message)
        {
            throw new NotImplementedException();
        }

        Task<IMessageContext<T>> IDataService<T>.PostAsync(IMessageContext<T> message)
        {
            throw new NotImplementedException();
        }


    }
}
