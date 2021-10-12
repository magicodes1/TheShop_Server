using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Domain.Exceptions;
using Shop.Domain.Repositoties;
using Shop.Persistence.Contexts;
using Shop.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Persistence.Repositories
{
    public sealed class ProductRepository : IProductRepository
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(ShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductResource>> GetProductByCategoryAndBrand(string categoryName, string brandName)
        {

            var products = await _context.Products.AsNoTracking()
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Where(p => p.Category.CategoryName.ToLower().CompareTo(categoryName.ToLower()) == 0 && p.Brand.BrandName.ToLower().CompareTo(brandName.ToLower()) == 0)
                .Select(p => _mapper.Map<ProductResource>(p))
                .ToListAsync();
                

            return products;
        }

        public async Task<IEnumerable<ProductResource>> FindProductByName(string name)
        {
            var products = await _context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Where(p => p.ProductName.Contains(name)).ToListAsync();
            var productList = _mapper.Map<IEnumerable<ProductResource>>(products);
            return productList;
        }

        public async Task<ProductDetailResource> GetProductById(int id)
        {
            var product = await _context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.Detail)
                .SingleOrDefaultAsync(p => p.ProductId == id);

            var productResource = _mapper.Map<ProductDetailResource>(product);

            return productResource;
        }
    }
}
