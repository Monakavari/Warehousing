using MediatR;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Warehouse.Commands.Create
{
    public class CreateWarehouseCommand : IRequest<ApiResponse>
    {
        public string WarehouseName { get; set; }
        public string WarehouseAddress { get; set; }
        public string WarehouseTel { get; set; }
    }
}
