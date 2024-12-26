using System;

namespace Warehousing.Domain.Dtos
{
    public class GetAllInvoicedProductResponseDto
    {
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
