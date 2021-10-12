using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Domain.Repositoties;
using Shop.Persistence.Contexts;
using Shop.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Persistence.Repositories
{
    public sealed class NavRepository : INavRepository
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public NavRepository(ShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryResource>> GetAllCategory()
        {
            var categories = await _context.Categories.AsNoTracking()
                .Include(c => c.CategoryBrands)
                .ThenInclude(cb => cb.Brand)
                .Select(p => _mapper.Map<Category,CategoryResource>(p))
                .ToListAsync();

            return categories;
        }
    }
}
