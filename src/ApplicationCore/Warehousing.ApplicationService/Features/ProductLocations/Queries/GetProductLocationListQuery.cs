using MediatR;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.ProductLocation.Queries
{
    public class GetProductLocationListQuery:IRequest<ApiResponse<List<GetProductLocationResponseVM>>>
    {
        public int WarehouseId { get; set; }
    }
}
