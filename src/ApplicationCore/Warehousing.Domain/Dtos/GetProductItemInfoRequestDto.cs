namespace Warehousing.Domain.Dtos
{
    public class GetProductItemInfoRequestDto
    {
        public int WarehouseId { get; set; }
        public int FiscalYearId { get; set; }
        public string ProductCode { get; set; }
        public int ProductRequestedCount { get; set; }
    }
}
