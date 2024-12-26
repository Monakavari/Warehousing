namespace Warehousing.Domain.Dtos
{
    public class GetWastageRialiStockResponseDto
    {
        public int WastageProductId { get; set; }
        public string WastageProductName { get; set; }
        public string WastageProductCode { get; set; }
        //موجودی تعدادی
        public int TotalWastageProductCount { get; set; }
        //موجودی ریالی کل کالا - خرید
        public int TotalWastagePurchasePrice { get; set; }
        //موجودی ریالی کل کالا - فروش
        public int TotalWastageSalePrice { get; set; }
        //موجودی ریالی کل کالا - مصرف کننده
        public int TotalWastageCoverPrice { get; set; }
    }
}
