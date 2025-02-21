using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;
using Warehousing.Domain.Dtos;

namespace Warehousing.ApplicationService.Services.Contracts
{
    public interface IGeneralService
    {
        Task<ApiResponse<List<GetDropDownListResponseDto>>> FiscalYearListDropDown(CancellationToken cancellationToken);
        Task<ApiResponse<List<GetDropDownListResponseDto>>> CountryListDropDown(CancellationToken cancellationToken);
        Task<ApiResponse<List<GetDropDownListResponseDto>>> SupplierListDropDown(CancellationToken cancellationToken);
        Task<ApiResponse<List<GetDropDownListResponseDto>>> ProductExpireDateListDropDown(GetProductExpireDateRequestForDropDown request, CancellationToken cancellationToken);
        Task<ApiResponse<List<GetDropDownListResponseDto>>> GetWastageProductExpireDateForDropDown(GetProductExpireDateRequestForDropDown request, CancellationToken cancellationToken);
        Task<ApiResponse<List<GetDropDownListResponseDto>>> ProductLocationListDropDown(int warehouseId, CancellationToken cancellationToken);
        Task<ApiResponse<List<GetDropDownListResponseDto>>> ProductListDropDown(CancellationToken cancellationToken);
        Task<ApiResponse<List<GetDropDownListResponseDto>>> WarehouseListDropDown(CancellationToken cancellationToken);
        Task<ApiResponse<List<GetDropDownListResponseDto>>> WarehouseUserOrientedListDropDown(string UserIdInWarehouse, CancellationToken cancellationToken);
        Task<ApiResponse<List<GetDropDownListResponseDto>>> CustomerListDropDown(int warehouse, CancellationToken cancellationToken);
    }
}
