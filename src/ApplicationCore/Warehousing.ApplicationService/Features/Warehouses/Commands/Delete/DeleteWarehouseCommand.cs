using MediatR;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Warehouse.Commands.Delete
{
    public class DeleteWarehouseCommand : IRequest<ApiResponse>
    {
        public int Id { get; set; }
    }
}
