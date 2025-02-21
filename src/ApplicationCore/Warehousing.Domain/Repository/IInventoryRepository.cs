using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.Domain.Repository
{
    public interface IInventoryRepository : IBaseRepository<Inventory>
    {
        Task<Inventory> GetParentInfo(int referenceId, CancellationToken cancellationToken);
        Task<List<GetProductStockResponseDto>> GetProductStock(int warehouseId, int fiscalYearId, CancellationToken cancellationToken);
        Task<List<GetDropDownListResponseDto>> GetProductExpireDateForDropDown(GetProductExpireDateRequestForDropDown request, CancellationToken cancellationToken);
        Task<List<GetDropDownListResponseDto>> GetWastageProductExpireDateForDropDown(GetProductExpireDateRequestForDropDown request, CancellationToken cancellationToken);
        Task<int> GetPhysicalStockForEachBranch(int inventoryId, CancellationToken cancellationToken);
        Task<int> GetPhysicalWastageStockForEachBranch(int inventoryId, CancellationToken cancellationToken);
        Task<GetPhysicalStockAndLocationResponseDto> GetPhysicalStockAndLocationForEachBranch(int inventoryId, CancellationToken cancellationToken);
        Task GetProductFromBranch(GetProductFromBranchDto request, CancellationToken cancellationToken);
        Task<List<GetProductStocksDto>> GetProductStocks(GetProductStocks request, CancellationToken cancellationToken);
        Task<List<Inventory>> GetInventorySoldProductsRecords(int invoiceId, CancellationToken cancellationToken);
        Task<List<ProductListExpireOrientedResponseDto>> GetProductListExpireOriented(ProductListExpireOrientedRequestDto request, CancellationToken cancellationToken);
        Task<List<TransferToNewFiscalYearDto>> TransferToNewFiscalYear(CloseFiscalYearDto request, CancellationToken cancellationToken);
    }
}
