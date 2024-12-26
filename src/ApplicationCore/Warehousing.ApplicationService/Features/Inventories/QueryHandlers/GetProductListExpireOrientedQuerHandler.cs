using Warehousing.ApplicationService.Features.Inventories.Queries;
using Warehousing.Common;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Features.Inventories.QueryHandlers
{
    public class GetProductListExpireOrientedQuerHandler : MediatR.IRequestHandler<ProductListExpireOrientedQuery, ApiResponse<List<ProductListExpireOrientedResponseDto>>>
    {
        #region Constructor
        private readonly IInventoryRepository _inventoryRepository;
        public GetProductListExpireOrientedQuerHandler(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        #endregion
        public async Task<ApiResponse<List<ProductListExpireOrientedResponseDto>>> Handle(ProductListExpireOrientedQuery request, CancellationToken cancellationToken)
        {
            var data = await _inventoryRepository.GetProductListExpireOriented(new ProductListExpireOrientedRequestDto
            {
                FiscalYearId = request.FiscalYearId,
                WarehouseId = request.WarehouseId,
            }, cancellationToken);

            return new ApiResponse<List<ProductListExpireOrientedResponseDto>>(true, ApiResponseStatusCode.Success, data, "عملیات با موفقیت انجام شد.");
        }
    }
}
