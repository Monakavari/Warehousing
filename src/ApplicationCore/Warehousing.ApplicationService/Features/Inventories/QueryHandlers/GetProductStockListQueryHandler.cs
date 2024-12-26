using Warehousing.ApplicationService.Features.Inventory.Queries;
using Warehousing.ApplicationService.Features.Product.Queries;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Features.Inventory.QueryHandlers
{
    public class GetProductStockListQueryHandler : MediatR.IRequestHandler<GetProductStockListQuery, ApiResponse<List<GetProductStockResponseDto>>>
    {
        #region Constructor
        private readonly IInventoryRepository _inventoryRepository;
        public GetProductStockListQueryHandler(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        #endregion
        public async Task<ApiResponse<List<GetProductStockResponseDto>>> Handle(GetProductStockListQuery request, CancellationToken cancellationToken)
        {
            var data = await _inventoryRepository.GetProductStockOfMainWarehouse(request.WarehouseId, request.FiscalYearId, cancellationToken);

            return new ApiResponse<List<GetProductStockResponseDto>>(true, ApiResponseStatusCode.Success, data, "عملیات با موفقیت انجام شد.");
        }
    }
}
