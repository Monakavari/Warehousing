using System.Collections.Generic;

namespace Warehousing.Domain.Dtos
{
    public class GetProductStocks
    {
        public List<int> ProductIds { get; set; } = new();
        public int WarehouseId { get; set; }
        public int FiscalYearId { get; set; }
    }
}
