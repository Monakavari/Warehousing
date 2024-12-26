using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Warehousing.Domain.Entities;

namespace Warehousing.DataAccess.EF.Configurations
{
    public class FiscalYearConfiguration : IEntityTypeConfiguration<FiscalYear>
    {
        public void Configure(EntityTypeBuilder<FiscalYear> builder)
        {
            builder
                  .Property(p => p.FiscalYearDescription)
                  .IsRequired(true)
                  .IsUnicode(true)
                  .HasMaxLength(100);
        }
    }
}
