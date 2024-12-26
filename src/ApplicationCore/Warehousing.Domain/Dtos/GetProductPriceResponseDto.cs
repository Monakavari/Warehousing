namespace Warehousing.Domain.Dtos
{
    public class GetProductPriceResponseDto
    {
        public int ProductPriceId { get; set; }
        public int PurchasePrice { get; set; }
        //قیمت فروش به عمده فروش یا فروشگاه
        public int SalesPrice { get; set; }
        //قیمت روی جلد - قیمت مصرف کننده
        public int CoverPrice { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int FiscalYearId { get; set; }
        public string ActionDate { get; set; }
    }
}
