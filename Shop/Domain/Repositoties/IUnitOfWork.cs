using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Domain.Repositoties
{
    public interface IUnitOfWork
    {
        INavRepository navRepository { get; }
        IProductRepository productRepository { get; }
        IBillRepository billRepository { get; }

        Task SaveChangesAsync(CancellationToken cancellationToken =default);
    }
}
