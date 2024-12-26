using Warehousing.ApplicationService.Features.Warehouse.Commands.Create;
using Warehousing.ApplicationService.Features.Warehouse.Commands.Update;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Domain.Entities;

namespace Warehousing.ApplicationService.VariableProfiles
{
    public class WarehouseProfile
    {
        public static Warehouse Map(CreateWarehouseCommand command)
        {
            return new Warehouse
            {
                WarehouseName = command.WarehouseName,
                WarehouseAddress = command.WarehouseAddress,
                WarehouseTel = command.WarehouseTel
            };
        }
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
        public static Warehouse Map(UpdateWarehouseCommand command)
        {
            return new Warehouse
            {
                Id = command.Id,
                WarehouseName = command.WarehouseName,
                WarehouseAddress = command.WarehouseAddress,
                WarehouseTel = command.WarehouseTel
            };
        }
    }
}
