namespace Warehousing.Domain.Dtos
{
    public class GetProductExpireDateRequestForDropDown
    {
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int FiscalYearId { get; set; }
    }
}
