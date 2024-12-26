using MediatR;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Product.Queries
{
    public class GetProductListQuery :IRequest<ApiResponse<List<GetProductResponseVM>>>
    {
    }
}
