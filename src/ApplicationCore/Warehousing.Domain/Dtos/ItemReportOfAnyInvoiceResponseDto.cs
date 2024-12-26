using System;

namespace Warehousing.Domain.Dtos
{
    public class ItemReportOfAnyInvoiceResponseDto
    {
        public int InvoiceId { get; set; }
        public string invoiceNo { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        public string ProductName { get; set; }
    }
}
