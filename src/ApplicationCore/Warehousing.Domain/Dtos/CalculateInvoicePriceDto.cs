using System.Collections.Generic;

namespace Warehousing.Domain.Dtos
{
    public class CalculateInvoicePriceDto
    {
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
    }
}
