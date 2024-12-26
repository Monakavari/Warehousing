using MediatR;
using Warehousing.Common;
using Warehousing.Domain.Dtos;

namespace Warehousing.ApplicationService.Features.ProductPrice.Queries
{
    public class GetProductPriceDetailQuery :IRequest<ApiResponse<GetProductPriceResponseDto>>
    {
        public int Id { get; set; }
    }
}
