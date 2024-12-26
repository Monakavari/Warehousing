namespace Warehousing.Domain.Dtos
{
    public class InvoiceItemInfoResponseDto
    {
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int PurchasePrice { get; set; }
        public int SalesPrice { get; set; }
        public int CoverPrice { get; set; }
    }
}
