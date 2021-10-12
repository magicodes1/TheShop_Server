using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Persistence.Configurations
{
    public class CategoryBrandConfig : IEntityTypeConfiguration<CategoryBrand>
    {
        public void Configure(EntityTypeBuilder<CategoryBrand> builder)
        {
            builder.HasKey(pk => new{ pk.CategoryId,pk.BrandId});

            builder.HasOne(cb => cb.Category).WithMany(category => category.CategoryBrands).HasForeignKey(fk => fk.CategoryId);
            builder.HasOne(cb => cb.Brand).WithMany(brand => brand.CategoryBrands).HasForeignKey(fk => fk.BrandId);
        }
    }
}
