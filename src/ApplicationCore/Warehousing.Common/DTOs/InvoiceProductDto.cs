namespace Warehousing.Common.DTOs
{
    public class InvoiceProductDto
    {
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        public int InvoiceId { get; set; }
        public string CreatorUserId { get; set; }
        public int PurchasePrice { get; set; }
        public int CoverPrice { get; set; }
        public int SalePrice { get; set; }
    }
}
