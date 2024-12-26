using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Warehousing.Domain.Entities.Base;

namespace Warehousing.Domain.Entities
{
    public class ProductLocation :BaseEntity
    {
        public ProductLocation()
        {
            Inventories = new List<Inventory>();
        }
        public int WarehouseId { get; set; }
        public string ProductLocationAddress { get; set; }


        [ForeignKey("WarehouseId")]
        public Warehouse warehouse { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }

    }
}
