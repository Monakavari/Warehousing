using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;
using Warehousing.Domain.Dtos;

namespace Warehousing.ApplicationService.Services.Contracts
{
    public interface IGeneralService
    {
        Task<List<GetDropDownListResponseDto>> FiscalYearListDropDown(CancellationToken cancellationToken);
        Task<List<GetDropDownListResponseDto>> CountryListDropDown(CancellationToken cancellationToken);
        Task<List<GetDropDownListResponseDto>> SupplierListDropDown(CancellationToken cancellationToken);
        Task<List<GetDropDownListResponseDto>> ProductExpireDateListDropDown(GetProductExpireDateRequestForDropDown request, CancellationToken cancellationToken);
        Task<List<GetDropDownListResponseDto>> GetWastageProductExpireDateForDropDown(GetProductExpireDateRequestForDropDown request, CancellationToken cancellationToken);
        Task<List<GetDropDownListResponseDto>> ProductLocationListDropDown(int warehouseId, CancellationToken cancellationToken);
        Task<List<GetDropDownListResponseDto>> WarehouseUserOrientedListDropDown(string UserIdInWarehouse, CancellationToken cancellationToken);
    }
}
