using MediatR;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Suppliers.Commands.Delete
{
    public class DeleteSupplierCommand : IRequest<ApiResponse>
    {
        public int Id { get; set; }
    }
}
