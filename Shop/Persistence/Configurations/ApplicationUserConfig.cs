using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Persistence.Configurations
{
    public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            //builder.en<ApplicationUser>(b =>
            //{
            //    b.HasMany(e => e.Bills)
            //    .WithOne(p => p.User)
            //    .HasForeignKey(ac => ac.UserId)
            //    .IsRequired();
            //});
            
            builder.HasMany(au => au.Bills).WithOne(bill => bill.User).HasForeignKey(fk => fk.UserId).IsRequired();

            
        }
    }
}
