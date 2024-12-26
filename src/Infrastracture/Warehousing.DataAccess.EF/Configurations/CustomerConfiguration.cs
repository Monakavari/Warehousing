using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehousing.Domain.Entities;

namespace Warehousing.DataAccess.EF.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
               .Property(x => x.CustomerName)
               .IsRequired(true)
               .IsUnicode(true)
               .HasMaxLength(100);

            builder
              .Property(x => x.EconomicCode)
              .IsRequired(true)
              .IsUnicode(true)
              .HasMaxLength(100);

            builder
              .Property(x => x.CustomerAddress)
              .IsRequired(true)
              .IsUnicode(true)
              .HasMaxLength(500); 

            builder
              .Property(x => x.CustomerTel)
              .IsRequired(true)
              .IsUnicode(true)
              .HasMaxLength(11);

            builder
                .HasOne(x => x.Warehouse)
                .WithMany(x => x.Customers)
                .HasForeignKey(x => x.WarehouseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
