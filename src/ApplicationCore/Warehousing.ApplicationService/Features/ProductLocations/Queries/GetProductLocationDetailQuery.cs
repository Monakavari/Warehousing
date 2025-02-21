using MediatR;
using Warehousing.Common;
using Warehousing.Domain.Dtos;

namespace Warehousing.ApplicationService.Features.ProductLocations.Queries
{
    public class GetProductLocationDetailQuery :IRequest<ApiResponse<ProductLocationResponseDto>>
    {
        public int Id { get; set; }
    }
}
