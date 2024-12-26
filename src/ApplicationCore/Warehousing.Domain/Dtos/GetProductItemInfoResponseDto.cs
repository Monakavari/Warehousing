namespace Warehousing.Domain.Dtos
{
    public class GetProductItemInfoResponseDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int PurchasePrice { get; set; }
        public int SalesPrice { get; set; }
        public int CoverPrice { get; set; }
        public int ProductStock { get; set; }
        public int TotalRowPrice { get; set; }
    }
}
