using MediatR;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Warehouse.Queries
{
    public class GetWarehouseListQuery : IRequest<ApiResponse<List<GetWarehouseResponseVM>>>
    {
    }
}
