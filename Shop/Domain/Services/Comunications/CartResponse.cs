using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.Services.Comunications
{
    public class CartResponse:BaseResponse
    {
        public CartResponse(bool success,string message):base(success,message)
        {

        }
    }
}
