namespace Warehousing.Domain.Dtos
{
    public class GetPhysicalStockAndLocationResponseDto
    {
        public int StockCount { get; set; }
        public int? ProductLocationId { get; set; }
        public string ProductLocationAddress { get; set; }
    }
}
