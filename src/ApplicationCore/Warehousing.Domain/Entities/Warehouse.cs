using System.Collections.Generic;
using Warehousing.Domain.Entities.Base;

namespace Warehousing.Domain.Entities
{
    public class Warehouse:BaseEntity
    {
        public Warehouse()
        {
            Inventories = new List<Inventory>();
            ProductLocations = new List<ProductLocation>();
            UserWarehouses = new List<UserWarehouse>();
            Customers = new List<Customer>();
            Invoices = new List<Invoice>(); 
        }
        public string WarehouseName { get; set; }
        public string WarehouseAddress { get; set; }
        public string WarehouseTel { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<ProductLocation> ProductLocations { get; set; }
        public virtual ICollection<UserWarehouse> UserWarehouses { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
