using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.Domain.Repository
{
    public interface IWarehouseRepository :IBaseRepository<Warehouse>
    {
        Task<bool> IsExistWarehouseName(string warehouseName, CancellationToken cancellationToken);
        Task<List<GetDropDownListResponseDto>> WarehouseListDropDown(CancellationToken cancellationToken);
        Task<bool> IsExistWarehouse(string warehouseName, string warehouseAddress, CancellationToken cancellationToken);
        Task<List<GetDropDownListResponseDto>> WarehouseUserOrientedListDropDown(string UserIdInWarehouse, CancellationToken cancellationToken);
    }
}
