using Shop.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.Services.Comunications
{
    public class ProductResponse<T>:BaseResponse
    {

        public T data { get; set; } = default(T);

        public ProductResponse(bool success, string message, T data) : base(success, message)
        {
            this.data = data;
        }
    }
}
