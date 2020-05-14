using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace XF.CQRS.Abstractions
{
    public class CommandResponse<T> : ICommandResponse<T> where T : class, new()
    {
        private HttpStatusCode _HttpStatuse;
        public HttpStatusCode HttpStatus
        {
            get { return _HttpStatuse; }
            set
            {
                _HttpStatuse = value;
                _IsOkay = value == HttpStatusCode.OK ? true : false;
            }
        }
        public string Message { get; set; }
        private bool _IsOkay;
        public bool IsOkay
        {
            get { return _IsOkay; }
            set
            {
                _IsOkay = value;
                _HttpStatuse = value ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
            }
        }
        public T Model { get; set; }

        public int Affected { get; set; }
    }
}
