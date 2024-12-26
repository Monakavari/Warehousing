using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehousing.Domain.Entities;

namespace Warehousing.DataAccess.EF.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
               .Property(x => x.ProductName)
               .IsRequired(true)
               .IsUnicode(true)
               .HasMaxLength(100);

            builder
              .Property(x => x.ProductCode)
              .IsRequired(true)
              .IsUnicode(true)
              .HasMaxLength(100);

            builder
                .HasOne(x => x.Country)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CountryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
              .HasOne(x => x.Supplier)
              .WithMany(x => x.Products)
              .HasForeignKey(x => x.SupplierId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
