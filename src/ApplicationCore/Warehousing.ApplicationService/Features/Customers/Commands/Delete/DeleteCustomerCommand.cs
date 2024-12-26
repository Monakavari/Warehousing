using MediatR;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Customers.Commands.Delete
{
    public class DeleteCustomerCommand:IRequest<ApiResponse>
    {
        public int Id { get; set; }
    }
}
