using Warehousing.ApplicationService.Services.Contracts;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;
using Warehousing.DataAccess.EF.Repository;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Services.Implementations
{
    public class GeneralService : IGeneralService
    {
        #region Constructor
        private readonly IFiscalYearRepository _fiscalyearRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IProductLocationRepository _productLocationRepository;
        private readonly IProductRepository _productRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly ICustomerRepository _customerRepository;
        public GeneralService(IFiscalYearRepository fiscalyearRepository,
                              ISupplierRepository supplierRepository,
                              ICountryRepository countryRepository,
                              IInventoryRepository inventoryRepository,
                              IProductLocationRepository productLocationRepository,
                              IProductRepository productRepository,
                              IWarehouseRepository warehouseRepository,
                              ICustomerRepository customerRepository)
        {
            _fiscalyearRepository = fiscalyearRepository;
            _supplierRepository = supplierRepository;
            _countryRepository = countryRepository;
            _inventoryRepository = inventoryRepository;
            _productLocationRepository = productLocationRepository;
            _productRepository = productRepository;
            _warehouseRepository = warehouseRepository;
            _customerRepository = customerRepository;
        }
        #endregion Constructor
        public async Task<List<GetDropDownListResponseDto>> FiscalYearListDropDown(CancellationToken cancellationToken)
        {
            var result = await _fiscalyearRepository.FiscalYearListDropDown(cancellationToken);

            return result;
        }
        public async Task<List<GetDropDownListResponseDto>> CountryListDropDown(CancellationToken cancellationToken)
        {
            var result = await _countryRepository.CountryListDropDown(cancellationToken);

            return result;
        }
        public async Task<List<GetDropDownListResponseDto>> SupplierListDropDown(CancellationToken cancellationToken)
        {
            var result = await _supplierRepository.SupplierListDropDown(cancellationToken);

            return result;
        }
        public async Task<List<GetDropDownListResponseDto>> ProductExpireDateListDropDown(GetProductExpireDateRequestForDropDown request, CancellationToken cancellationToken)
        {
            var result = await _inventoryRepository.GetProductExpireDateForDropDown(request, cancellationToken);

            return result;
        }
        public async Task<List<GetDropDownListResponseDto>> GetWastageProductExpireDateForDropDown(GetProductExpireDateRequestForDropDown request, CancellationToken cancellationToken)
        {
            var result = await _inventoryRepository.GetWastageProductExpireDateForDropDown(request, cancellationToken);

            return result;
        }
        public async Task<List<GetDropDownListResponseDto>> ProductLocationListDropDown(int warehouseId, CancellationToken cancellationToken)
        {
            var result = await _productLocationRepository.ProductLocationListDropDown(warehouseId, cancellationToken);

            return result;
        }
        public async Task<List<GetDropDownListResponseDto>> ProductListDropDown(CancellationToken cancellationToken)
        {
            var result = await _productRepository.ProductListDropDown(cancellationToken);

            return result;
        }
        public async Task<List<GetDropDownListResponseDto>> WarehouseListDropDown(CancellationToken cancellationToken)
        {
            var result = await _warehouseRepository.WarehouseListDropDown(cancellationToken);

            return result;
        }
        public async Task<List<GetDropDownListResponseDto>> WarehouseUserOrientedListDropDown(string UserIdInWarehouse, CancellationToken cancellationToken)
        {
            var result = await _warehouseRepository.WarehouseUserOrientedListDropDown(UserIdInWarehouse, cancellationToken);

            return result;
        }
        public async Task<List<GetDropDownListResponseDto>> CustomerListDropDown(int warehouse, CancellationToken cancellationToken)
        {
            var result = await _customerRepository.CustomerListDropDown(warehouse, cancellationToken);

            return result;
        }
    }
}
