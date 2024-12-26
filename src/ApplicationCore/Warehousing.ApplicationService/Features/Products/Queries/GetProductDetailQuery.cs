using MediatR;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Product.Queries
{
    public class GetProductDetailQuery : IRequest<ApiResponse<GetProductResponseVM>>
    {
        public int Id { get; set; }
    }
}
