namespace Warehousing.Domain.Dtos
{
    public class GetProductStockResponseDto
    {
        public int ProductId { get; set; }
        public int FiscalYeartId { get; set; }
        public int WarehouseId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int TotalProductCount { get; set; }
        public int TotalProductWaste { get; set; }
    }
}
