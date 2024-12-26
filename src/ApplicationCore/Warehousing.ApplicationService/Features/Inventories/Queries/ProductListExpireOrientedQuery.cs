using MediatR;
using Warehousing.Common;
using Warehousing.Domain.Dtos;

namespace Warehousing.ApplicationService.Features.Inventories.Queries
{
    public class ProductListExpireOrientedQuery :IRequest<ApiResponse<List<ProductListExpireOrientedResponseDto>>>
    {
        public int FiscalYearId { get; set; }
        public int WarehouseId { get; set; }
    }
}
