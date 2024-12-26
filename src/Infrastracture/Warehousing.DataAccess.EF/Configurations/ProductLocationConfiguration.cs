using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehousing.Domain.Entities;

namespace Warehousing.DataAccess.EF.Configurations
{
    internal class ProductLocationConfiguration : IEntityTypeConfiguration<ProductLocation>
    {
        public void Configure(EntityTypeBuilder<ProductLocation> builder)
        {
            builder
               .Property(x => x.ProductLocationAddress)
               .IsRequired(true)
               .IsUnicode(true)
               .HasMaxLength(500);

            builder
               .HasOne(x => x.warehouse)
               .WithMany(x => x.ProductLocations)
               .HasForeignKey(x => x.WarehouseId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
