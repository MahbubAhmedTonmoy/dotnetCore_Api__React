using System;
using System.Net;

namespace API.Application.Error
{
    public class RestException : Exception
    {
        public HttpStatusCode Code {get;}
        public object Error {get;}
        public RestException(HttpStatusCode code, object error = null)
        {
            Code = code;
            Error = error;
        }
    }
}