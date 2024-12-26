using MediatR;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Customers.Commands.Update
{
    public class UpdateCustomerCommand : IRequest<ApiResponse>
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerTel { get; set; }
        public string EconomicCode { get; set; }
        public int WarehouseId { get; set; }
        public string ModifierUserId { get; set; }
    }
}
