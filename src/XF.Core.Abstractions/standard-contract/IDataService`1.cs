using XF.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XF.Rest.Abstractions
{
    public interface IDataService<T> where T : class, new()
    {
        //IResponse<T> Get(IParameters parameters);

        //IResponse<T> Delete(IParameters parameters);

        //IResponse<T> Post(T model);

        //IResponse<T> Put(T model, IParameters parameters);

        //Task<IResponse<T>> GetAsync(IParameters parameters);

        //Task<IResponse<T>> DeleteAsync(IParameters parameters);

        //Task<IResponse<T>> PostAsync(T model);

        //Task<IResponse<T>> PutAsync(T model, IParameters parameters);

        IMessageContext<T> Get(IMessageContext<T> message);

        IMessageContext<T> Delete(IMessageContext<T> message);

        IMessageContext<T> Post(IMessageContext<T> message);

        IMessageContext<T> Put(IMessageContext<T> message);


        Task<IMessageContext<T>> GetAsync(IMessageContext<T> message);

        Task<IMessageContext<T>> DeleteAsync(IMessageContext<T> message);

        Task<IMessageContext<T>> PostAsync(IMessageContext<T> message);

        Task<IMessageContext<T>> PutAsync(IMessageContext<T> message);

    }
}
