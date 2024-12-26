using System.Collections.Generic;
using Warehousing.Domain.Entities.Base;

namespace Warehousing.Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public Supplier()
        {
            Products = new List<Product>();
        }
        public string SupplierName { get; set; }
        public string SupplerTel { get; set; }
        public string SupplerWebsite { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
