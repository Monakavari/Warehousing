using MediatR;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Warehouse.Commands.Update
{
    public class UpdateWarehouseCommand : IRequest<ApiResponse>
    {
        public int Id { get; set; }
        public string WarehouseName { get; set; }
        public string WarehouseAddress { get; set; }
        public string WarehouseTel { get; set; }
    }
}
