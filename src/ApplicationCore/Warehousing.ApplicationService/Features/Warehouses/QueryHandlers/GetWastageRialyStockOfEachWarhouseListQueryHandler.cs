using Warehousing.ApplicationService.Features.Warehouses.Queries;
using Warehousing.Common;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Features.Warehouses.QueryHandlers
{
    public class GetWastageRialyStockOfEachWarhouseListQueryHandler : MediatR.IRequestHandler<GetWastageRialyStockOfEachWarhouseListQuery, ApiResponse<List<GetWastageRialiStockResponseDto>>>
    {
        #region Constructor
        private readonly IRialiStockRepository _rialiStockRepository;
        public GetWastageRialyStockOfEachWarhouseListQueryHandler(IRialiStockRepository rialiStockRepository)
        {
            _rialiStockRepository = rialiStockRepository;
        }
        #endregion
        public async Task<ApiResponse<List<GetWastageRialiStockResponseDto>>> Handle(GetWastageRialyStockOfEachWarhouseListQuery request, CancellationToken cancellationToken)
        {
            var data = await _rialiStockRepository.GetWastageRialiStock(request.FiscalYearId, request.WarehouseId, cancellationToken);
            return new ApiResponse<List<GetWastageRialiStockResponseDto>>(true, ApiResponseStatusCode.Success, data, "عملیات با موفقیت انجام شد");
        }
    }
}
