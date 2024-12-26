using MediatR;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;
using Warehousing.Domain.Dtos;

namespace Warehousing.ApplicationService.Features.Inventory.Queries
{
    public class GetCustomerListQuery : IRequest<ApiResponse<List<GetCustomerResponseVM>>>
    {
        public string UserId { get; set; }
    }
}
