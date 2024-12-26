using MediatR;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Inventories.Commands.Create
{
    public class TransferItemsToNewFiscalYearRequestCommand :IRequest<ApiResponse>
    {
        public int WarehouseId { get; set; }
        public int FiscalYearId { get; set; }
        public string UserId { get; set; }
    }
}
