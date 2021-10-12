using Shop.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.Services.Comunications
{
    public class NavResponse:BaseResponse
    {
        public IEnumerable<CategoryResource> data { get; set; }

        public NavResponse(bool success, string message, IEnumerable<CategoryResource> data) : base(success, message)
        {
            this.data = data;
        }
    }
}
