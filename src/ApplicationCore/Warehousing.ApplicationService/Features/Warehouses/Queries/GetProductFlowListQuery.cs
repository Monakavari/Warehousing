using MediatR;
using Warehousing.Common;
using Warehousing.Domain.Dtos;

namespace Warehousing.ApplicationService.Features.Warehouses.Queries
{
    public class GetProductFlowListQuery : IRequest<ApiResponse<List<GetProductFlowResponseDto>>>
    {
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int FiscalYearId { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
    }
}
