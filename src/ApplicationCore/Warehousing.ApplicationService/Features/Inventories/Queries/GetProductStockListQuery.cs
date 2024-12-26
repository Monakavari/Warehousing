using MediatR;
using Warehousing.Common;
using Warehousing.Domain.Dtos;

namespace Warehousing.ApplicationService.Features.Inventory.Queries
{
    public class GetProductStockListQuery : IRequest<ApiResponse<List<GetProductStockResponseDto>>>
    {
        public int WarehouseId { get; set; }
        public int FiscalYearId { get; set; }
    }
}
