using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XF.Rest.Abstractions
{
    public interface IDataRequestService
    {
        IMessageContext<T> Get<T>(IMessageContext<T> request) where T : class, new();

        IMessageContext<T> Delete<T>(IMessageContext<T> request) where T : class, new();

        IMessageContext<T> Post<T>(IMessageContext<T> request) where T : class, new();

        IMessageContext<T> Put<T>(IMessageContext<T> request) where T : class, new();


        Task<IMessageContext<T>> GetAsync<T>(IMessageContext<T> request) where T : class, new();

        Task<IMessageContext<T>> DeleteAsync<T>(IMessageContext<T> request) where T : class, new();

        Task<IMessageContext<T>> PostAsync<T>(IMessageContext<T> request) where T : class, new();

        Task<IMessageContext<T>> PutAsync<T>(IMessageContext<T> request) where T : class, new();

    }
}
