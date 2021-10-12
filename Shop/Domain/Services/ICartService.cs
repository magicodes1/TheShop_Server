using Shop.Domain.Services.Comunications;
using Shop.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Domain.Services
{
    public interface ICartService
    {
        Task<CartResponse> AddToCart(AddToCartResource cartResource,CancellationToken cancellationToken=default);
    }
}
