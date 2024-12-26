using System.Collections;
using System.Collections.Generic;
using Warehousing.Domain.Entities.Base;

namespace Warehousing.Domain.Entities
{
    public class Customer :BaseEntity
    {
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerTel { get; set; }
        public string EconomicCode { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
