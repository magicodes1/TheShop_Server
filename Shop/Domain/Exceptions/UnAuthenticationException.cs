using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Shop.Domain.Exceptions
{
    public class UnAuthenticationException : Exception
    {
        public HttpStatusCode Status { get; private set; } = HttpStatusCode.Unauthorized;
        public UnAuthenticationException(string message):base(message)
        {

        }
    }
}
