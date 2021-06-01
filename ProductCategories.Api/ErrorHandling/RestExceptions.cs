using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProductCategories.Api.ErrorHandling
{
    public class RestException : Exception
    {
        public HttpStatusCode Code;
        public object Errors;

        public RestException(HttpStatusCode code, object errors = null)
        {
            Code = code;
            Errors = errors;
        }
    }
}
