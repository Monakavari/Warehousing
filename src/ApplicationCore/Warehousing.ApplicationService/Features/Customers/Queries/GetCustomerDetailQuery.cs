using MediatR;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Customers.Queries
{
    public class GetCustomerDetailQuery : IRequest<ApiResponse<GetCustomerResponseVM>>
    {
        public int Id { get; set; }
    }
}
