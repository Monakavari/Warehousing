using Warehousing.ApplicationService.Features.Warehouses.Queries;
using Warehousing.Common;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Features.Warehouses.QueryHandlers
{
    public class GetMainRialyStockOfEachWarhouseListQueryHandler : MediatR.IRequestHandler<GetMainRialyStockOfEachWarhouseListQuery, ApiResponse<List<GetMainRialiStockResponseDto>>>
    {
        #region Constructor
        private readonly IRialiStockRepository _rialiStockRepository;
        public GetMainRialyStockOfEachWarhouseListQueryHandler(IRialiStockRepository rialiStockRepository)
        {
            _rialiStockRepository = rialiStockRepository;
        }
        #endregion
        public async Task<ApiResponse<List<GetMainRialiStockResponseDto>>> Handle(GetMainRialyStockOfEachWarhouseListQuery request, CancellationToken cancellationToken)
        {
            var data = await _rialiStockRepository.GetMainRialiStock(request.FiscalYearId, request.WarehouseId, cancellationToken);
            return new ApiResponse<List<GetMainRialiStockResponseDto>>(true, ApiResponseStatusCode.Success, data, "عملیات با موفقیت انجام شد");
        }
    }
}
