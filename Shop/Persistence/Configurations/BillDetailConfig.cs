using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Persistence.Configurations
{
    public class BillDetailConfig : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.HasKey(pk => new { pk.BillId, pk.ProductId });

            builder.HasOne(billDetail => billDetail.Bill).WithMany(b => b.BillDetails).HasForeignKey(fk => fk.BillId);
            builder.HasOne(billDetail => billDetail.Product).WithMany(p => p.BillDetails).HasForeignKey(fk => fk.ProductId);
        }
    }
}
