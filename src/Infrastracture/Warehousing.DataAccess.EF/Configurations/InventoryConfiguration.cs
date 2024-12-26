using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Warehousing.Domain.Entities;

namespace Warehousing.DataAccess.EF.Configurations
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder
               .Property(x => x.Description)
               .IsRequired(true)
               .IsUnicode(true)
               .HasMaxLength(500);

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.Inventories)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                  .HasOne(x => x.Warehouse)
                  .WithMany(x => x.Inventories)
                  .HasForeignKey(x => x.WarehouseId)
                  .OnDelete(DeleteBehavior.Cascade);

            builder
                 .HasOne(x => x.FiscalYear)
                 .WithMany(x => x.Inventories)
                 .HasForeignKey(x => x.FiscalYearId)
                 .OnDelete(DeleteBehavior.Cascade);

            builder
                 .HasOne(x => x.ProductLocation)
                 .WithMany(x => x.Inventories)
                 .HasForeignKey(x => x.ProductLocationId)
                 .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.Invoice)
                .WithMany(x => x.Inventories)
                .HasForeignKey(x => x.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
