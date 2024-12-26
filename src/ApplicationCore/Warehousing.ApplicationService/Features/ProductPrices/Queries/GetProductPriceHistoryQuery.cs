using MediatR;
using Warehousing.Common;
using Warehousing.Domain.Dtos;

namespace Warehousing.ApplicationService.Features.ProductPrice.Queries
{
    public class GetProductPriceHistoryQuery:IRequest<ApiResponse<List<GetProductPriceResponseDto>>>
    {
        public int ProductId { get; set; }
    }
}
