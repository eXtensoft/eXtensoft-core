using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Text;
using XF.Api.Abstractions;
using XF.Core.Abstractions;
using XF.CQRS.Abstractions;
using XF.Rest.Abstractions;

namespace XF.Data.MongoDB
{
    public static class Extensions
    {
        public static DataResponse<T> Default<T>(this DataResponse<T> model,bool isOkay = true) where T : class, new()
        {
            model.IsOkay = isOkay;
            model.Status = new ResponseStatus().Default(isOkay);
            return model;
        }

        public static CommandResponse<T> Default<T>(this CommandResponse<T> model, bool isOkay = true) where T : class, new()
        {
            model.IsOkay = isOkay;
            model.HttpStatus = isOkay ? HttpStatusCode.OK : HttpStatusCode.Conflict;
            return model;
        }

        public static ResponseStatus Default(this ResponseStatus model,bool isOkay = true)
        {
            model.HttpStatus = HttpStatusCode.OK;            
            return model;
        }

        public static bool TryGetId<T>(this T model, out string id, string idPropertyName = "Id") where T : class, new()
        {
            bool b = false;
            id = String.Empty;
            PropertyInfo info = typeof(T).GetProperty(idPropertyName);
            if (info != null)
            {
                var obj = info.GetValue(model);
                if (obj != null)
                {
                    id = obj.ToString();
                    if (id.IsValidMongoId())
                    {
                        b = true;
                    }
                }
            }
            return b;
        }

        public static bool TryGett<T>(this T t,
            out object id) where T : class, new()
        {
            bool b = false;
            id = null;
            var type = typeof(T);
            var modelid = $"{type.Name}Id";
            PropertyInfo info = null;
            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (prop.Name.Equals("Id", StringComparison.OrdinalIgnoreCase))
                {
                    info = prop;
                    b = true;
                    break;
                }
                else if (prop.Name.Equals(modelid, StringComparison.OrdinalIgnoreCase))
                {
                    info = prop;
                    b = true;
                    break;
                }
            }
            if (b)
            {
                id = info.GetValue(t);
            }

            return b;
        }

        private static bool IsValidMongoId(this string id)
        {
            bool b = true;

            return b;
        }

        public static void OnException<T>(this DataResponse<T> response, 
            IApiRequestInfo request,
            HttpVerb httpVerb, 
            Exception ex, 
            IParameters parameters, 
            T model) where T : class, new()
        {
            response.Status.HttpStatus = HttpStatusCode.InternalServerError;
            response.Status.Message = ex.Unwind();
            if (request != null)
            {
                if (request.Response == null)
                {
                    request.Response = new List<Datapoint>();
                }
                request.Response.Add(new Datapoint() { Value = ex.Unwind(), Key = "message", Groupname = "exception" });
                request.Response.Add(new Datapoint() { Value = ex.StackTrace, Key = "stacktrace",  Groupname = "exception" });
                foreach (var parameter in parameters)
                {
                    request.Response.Add(new Datapoint() { Value = parameter.Value, Key = parameter.Key, Groupname = "param" });
                }
            }
        }

      

        public static void OnException<T>(this CommandResponse<T> response,
            IApiRequestInfo request,
            HttpVerb httpVerb,
            Exception ex,
            IParameters parameters,
            T model ) where T : class, new()
        {
            response.HttpStatus = HttpStatusCode.InternalServerError;
            if (request != null)
            {
                if (request.Response == null)
                {
                    request.Response = new List<Datapoint>();
                }
                request.Response.Add(new Datapoint() { Value = ex.Unwind(), Key = "message", Groupname = "exception" });
                request.Response.Add(new Datapoint() { Value = ex.StackTrace, Key = "stacktrace", Groupname = "exception" });
                foreach (var parameter in parameters)
                {
                    request.Response.Add(new Datapoint() { Value = parameter.Value, Key = parameter.Key, Groupname = "param" });
                }
            }
        }
    }
}
