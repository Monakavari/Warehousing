using MediatR;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Warehouse.Queries
{
    public class GetWarehouseDetailQuery : IRequest<ApiResponse<GetWarehouseResponseVM>>
    {
        public int Id { get; set; }
    }
}
