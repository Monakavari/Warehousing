using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehousing.Domain.Entities;

namespace Warehousing.DataAccess.EF.Configurations
{
    public class UserWarehouseConfiguration : IEntityTypeConfiguration<UserWarehouse>
    {
        public void Configure(EntityTypeBuilder<UserWarehouse> builder)
        {
            builder
                .HasOne(x => x.Warehouse)
                .WithMany(x => x.UserWarehouses)
                .HasForeignKey(x => x.WarehouseId)
                .OnDelete(DeleteBehavior.Cascade);

            //builder
            //    .HasOne(x => x.User)
            //    .WithMany(x => x.UserWarehouses)
            //    .HasForeignKey(x => x.UserIdInWarehouse)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
