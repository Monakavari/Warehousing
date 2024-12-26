using Warehousing.Domain.Entities.Base;

namespace Warehousing.Domain.Entities
{
    public class InvoiceItem :BaseEntity
    {
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        public int PurchasePrice { get; set; }
        public int SalePrice { get; set; }
        public int CoverPrice { get; set; }
        public virtual Product Product { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
