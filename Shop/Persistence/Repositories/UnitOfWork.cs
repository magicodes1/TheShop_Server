using AutoMapper;
using Shop.Domain.Repositoties;
using Shop.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Persistence.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ShopDbContext _dbContext;
        private readonly IMapper _mapper;



        private INavRepository _navRepository;
        private IProductRepository _productRepository;
        private IBillRepository _billRepository;

        public UnitOfWork(ShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public INavRepository navRepository => _navRepository ??= new NavRepository(_dbContext, _mapper);

        public IProductRepository productRepository => _productRepository ??= new ProductRepository(_dbContext, _mapper);

        public IBillRepository billRepository => _billRepository ??= new BillRepository(_dbContext);



        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
