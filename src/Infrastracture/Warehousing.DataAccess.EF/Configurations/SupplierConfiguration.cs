using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehousing.Domain.Entities;

namespace Warehousing.DataAccess.EF.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder
               .Property(x => x.SupplierName)
               .IsRequired(true)
               .IsUnicode(true)
               .HasMaxLength(100);

        }
    }
}
