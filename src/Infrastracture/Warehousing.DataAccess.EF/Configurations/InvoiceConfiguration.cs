using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehousing.Domain.Entities;

namespace Warehousing.DataAccess.EF.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder
               .Property(x => x.InvoiceNo)
               .IsRequired(true)
               .IsUnicode(true)
               .HasMaxLength(15);

            builder
                .HasOne(x => x.Warehouse)
                .WithMany(x => x.Invoices)
                .HasForeignKey(x => x.WarehouseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
           .HasOne(x => x.Customer)
           .WithMany(x => x.Invoices)
           .HasForeignKey(x => x.CustomerId)
           .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
