using AutoMapper;
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
    public sealed class BillRepository : IBillRepository
    {

        private readonly ShopDbContext _context;

        public BillRepository(ShopDbContext context)
        {
            _context = context;
        }

        public async Task AddBill(Bill bill)
        {
            await _context.Bills.AddAsync(bill);
        }

       
    }
}
