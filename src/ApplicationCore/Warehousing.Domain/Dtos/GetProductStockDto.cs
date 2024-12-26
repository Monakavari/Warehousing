namespace Warehousing.Domain.Dtos
{
    public class GetProductStockDto
    {
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int FiscalYearId { get; set; }
    }
}
