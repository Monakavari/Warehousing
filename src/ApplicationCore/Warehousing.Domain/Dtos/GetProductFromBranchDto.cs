using System.Collections.Generic;
using Warehousing.Common.DTOs;

namespace Warehousing.Domain.Dtos
{
    public class GetProductFromBranchDto
    {
        public int WarehouseId { get; set; }
        public int FiscalYearId { get; set; }
        public int InvoiceId { get; set; }
        public string UserId { get; set; }
        public List<InvoiceProductDto> InvoiceProducts { get; set; }
    }
}
