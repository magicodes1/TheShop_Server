using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Shop.Persistence.Contexts
{
    public class ShopDbContext : IdentityDbContext<ApplicationUser>
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CategoryBrand> CategoryBrands { get; set; }

        public DbSet<Bill> Bills { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<BillDetail> BillDetails { get; set; }

        public DbSet<ProductDetail> ProductDetails { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}
