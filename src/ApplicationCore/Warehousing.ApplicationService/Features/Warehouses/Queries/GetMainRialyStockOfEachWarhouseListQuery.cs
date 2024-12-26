using MediatR;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;
using Warehousing.Domain.Dtos;

namespace Warehousing.ApplicationService.Features.Warehouses.Queries
{
    public class GetMainRialyStockOfEachWarhouseListQuery : IRequest<ApiResponse<List<GetMainRialiStockResponseDto>>>
    {
        public int FiscalYearId { get; set; }
        public int WarehouseId { get; set; }
    }
}
