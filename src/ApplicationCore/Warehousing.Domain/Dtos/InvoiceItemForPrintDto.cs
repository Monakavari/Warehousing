namespace Warehousing.Domain.Dtos
{
    public class InvoiceItemForPrintDto
    {
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        public int ProductPrice { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
    }
}
