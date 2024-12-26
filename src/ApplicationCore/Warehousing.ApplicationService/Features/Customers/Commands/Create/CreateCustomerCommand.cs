using MediatR;
using Warehousing.Common;
using Warehousing.Common.Enums;

namespace Warehousing.ApplicationService.Features.Inventory.Commands.Create
{
    public class CreateCustomerCommand : IRequest<ApiResponse>
    {
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerTel { get; set; }
        public string EconomicCode { get; set; }
        public int WarehouseId { get; set; }
        public string UserId { get; set; }
    }
}
