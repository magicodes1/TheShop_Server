using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Persistence.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(pk => pk.ProductId);
            //product has 1 detail
            builder.HasOne(product => product.Detail).WithOne(detail=> detail.Product).HasForeignKey<ProductDetail>(fk=>fk.ProductId);

            //Brand has many products
            builder.HasOne(product => product.Brand).WithMany(brand => brand.Products).HasForeignKey(fk=>fk.BrandId);
            //category has many products
            builder.HasOne(product => product.Category).WithMany(category => category.Products).HasForeignKey(fk=>fk.CategoryId);
            

            
            
        }
    }
}
