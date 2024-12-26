using System.Collections.Generic;
using Warehousing.Common.Enums;
using Warehousing.Domain.Entities.Base;

namespace Warehousing.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            Inventories = new List<Inventory>();
            ProductPrices = new List<ProductPrice>();
            InvoiceItemes = new List<InvoiceItem>();
        }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public PackingType PackingType { get; set; }
        public int CountInPacking { get; set; }
        public int ProductWeight { get; set; }
        public string ProductImage { get; set; }
        //1=یخچالی
        //2=غیریخچالی
        public bool IsRefregrator { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<ProductPrice> ProductPrices { get; set; }
        public virtual ICollection<InvoiceItem> InvoiceItemes { get; set; }
    }
}
