using MediatR;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Users.Queries
{
    public class GetUserWarehouseListQuery :IRequest<ApiResponse<List<int>>>
    {
        public int UserWarehouseId { get; set; }
    }
}
