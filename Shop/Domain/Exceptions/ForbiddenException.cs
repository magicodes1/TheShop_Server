using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Shop.Domain.Exceptions
{
    public class ForbiddenException:Exception
    {
        public HttpStatusCode Status { get; private set; } = HttpStatusCode.Forbidden;

        public ForbiddenException(string message) : base(message)
        {

        }
    }
}
