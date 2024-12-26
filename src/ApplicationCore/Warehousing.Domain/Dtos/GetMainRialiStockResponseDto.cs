namespace Warehousing.Domain.Dtos
{
    public class GetMainRialiStockResponseDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        //موجودی تعدادی
        public int TotalProductCount { get; set; }
        //موجودی ریالی کل کالا - خرید
        public int TotalPurchasePrice { get; set; }
        //موجودی ریالی کل کالا - فروش
        public int TotalSalePrice { get; set; }
        //موجودی ریالی کل کالا - مصرف کننده
        public int TotalCoverPrice { get; set; }
    }
}
