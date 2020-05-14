//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Net.Http;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Linq;

//namespace XF.Data.Concurrent
//{
//    public static class Taskmaster
//    {
//        public static HttpClient CreateClient(string baseUrl)
//        {
//            HttpClient client = new HttpClient();
//            client.BaseAddress = new Uri(baseUrl);
//            client.DefaultRequestHeaders.Add("Accept", "application/json");
//            return client;
//        }

//        public static async Task<DataTable> Execute<T>(HttpClient client,
//            IEnumerable<string> urls,
//            Func<List<T>,DataTable> process) where T : class, new()
//        {
//            CancellationToken token = new CancellationToken();
//            IEnumerable<Task<Data<T>>> tasks = from url
//                                               in urls
//                                               select Get<T>(url, client, token);
//            return await Task.WhenAll(tasks).ContinueWith((antecedent) => {
//                var list = antecedent.Result.ToModels();
//                return process(list.ToList());
//            });

//        }

//        public static async Task<Data<T>> Get<T>(string url,
//            HttpClient client,
//            CancellationToken token) where T: class, new()
//        {
//            Data<T> data = new Data<T>();
//            HttpResponseMessage response = await client.GetAsync(url, token);
//            if (response.IsSuccessStatusCode)
//            {
//                string body = await response.Content.ReadAsStringAsync();
//                try
//                {
//                    T model = JsonConvert.DeserializeObject<T>(body);
//                    data.Model = model;
//                }
//                catch (Exception ex)
//                {
//                    data.Message = ex.Message;
//                }
//            }

//            return data;
//        }

//    }
//}
