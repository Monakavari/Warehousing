namespace Warehousing.ApplicationService.ViewModels
{
    public class GetCustomerResponseVM
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerTel { get; set; }
        public string EconomicCode { get; set; }
        public int WarehouseId { get; set; }
    }
}
