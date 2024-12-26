using System;

namespace Warehousing.Domain.Dtos
{
    public class TransferToNewFiscalYearDto
    {
        public int ProductId { get; set; }
        public int TotalProductCount { get; set; }
        public DateTime ExpireDate { get; set; }
        public int InventoryId { get; set; }
    }
}
