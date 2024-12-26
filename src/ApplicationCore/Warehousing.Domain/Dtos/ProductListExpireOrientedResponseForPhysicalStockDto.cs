using System;

namespace Warehousing.Domain.Dtos
{
    public class ProductListExpireOrientedResponseForPhysicalStockDto
    {
        public int ProductId { get; set; }
        public int InventoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int TotalProductCount { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
