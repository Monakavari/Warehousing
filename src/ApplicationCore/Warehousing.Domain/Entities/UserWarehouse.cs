using Warehousing.Domain.Entities.Base;

namespace Warehousing.Domain.Entities
{
    public class UserWarehouse : BaseEntity
    {
        public string UserIdInWarehouse { get; set; }
        public int WarehouseId { get; set; }
        public virtual ApplicationUsers UserInWarehouse { get; set; }
        public virtual Warehouse Warehouse { get; set; }

    }
}
