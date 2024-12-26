using MediatR;
using Warehousing.Common;
using Warehousing.Domain.Dtos;

namespace Warehousing.ApplicationService.Features.ProductPrice.Queries
{
    public class GetProductPriceListQuery : IRequest<ApiResponse<List<GetProductPriceResponseDto>>>
    {
        public int FiscalYearId { get; set; }
    }
}
