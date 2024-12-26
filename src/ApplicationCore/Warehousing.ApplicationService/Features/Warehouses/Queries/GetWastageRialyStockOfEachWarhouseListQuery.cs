using MediatR;
using Warehousing.Common;
using Warehousing.Domain.Dtos;

namespace Warehousing.ApplicationService.Features.Warehouses.Queries
{
    public class GetWastageRialyStockOfEachWarhouseListQuery : IRequest<ApiResponse<List<GetWastageRialiStockResponseDto>>>
    {
        public int FiscalYearId { get; set; }
        public int WarehouseId { get; set; }
    }
}
