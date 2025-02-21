using Warehousing.ApplicationService.Features.Warehouse.Commands.Create;
using Warehousing.ApplicationService.Features.Warehouse.Commands.Update;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Domain.Entities;

namespace Warehousing.ApplicationService.VariableProfiles
{
    public class WarehouseProfile
    {
        public static GetWarehouseResponseVM Map(Warehouse command)
        {
            return new GetWarehouseResponseVM
            {
                Id = command.Id,
                WarehouseName = command.WarehouseName,
                WarehouseAddress = command.WarehouseAddress,
                WarehouseTel = command.WarehouseTel
            };
        }
    }
}
