using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehousing.Domain.Entities;

namespace Warehousing.DataAccess.EF.Configurations
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder
                  .Property(p => p.WarehouseName)
                  .IsRequired(true)
                  .IsUnicode(true)
                  .HasMaxLength(100);

            builder
                  .Property(p => p.WarehouseAddress)
                  .IsRequired(true)
                  .IsUnicode(true)
                  .HasMaxLength(100);

            builder
                  .Property(p => p.WarehouseTel)
                  .IsRequired(true)
                  .IsUnicode(true)
                  .HasMaxLength(8);
        }
    }
}
