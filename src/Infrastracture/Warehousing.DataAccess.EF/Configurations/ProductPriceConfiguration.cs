using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehousing.Domain.Entities;

namespace Warehousing.DataAccess.EF.Configurations
{
    internal class ProductPriceConfiguration : IEntityTypeConfiguration<ProductPrice>
    {
        public void Configure(EntityTypeBuilder<ProductPrice> builder)
        {
            builder
                 .HasOne(x => x.FiscalYear)
                 .WithMany(x => x.ProductPrices)
                 .HasForeignKey(x => x.FiscalYearId)
                 .OnDelete(DeleteBehavior.Cascade);

            builder
              .HasOne(x => x.Product)
              .WithMany(x => x.ProductPrices)
              .HasForeignKey(x => x.ProductId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
