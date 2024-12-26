using Warehousing.ApplicationService.Features.Warehouses.Queries;
using Warehousing.Common;
using Warehousing.DataAccess.EF.Repository;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Features.Warehouses.QueryHandlers
{
    public class GetProductFlowQueryHandler : MediatR.IRequestHandler<GetProductFlowListQuery, ApiResponse<List<GetProductFlowResponseDto>>>
    {
        #region Constructor
        private readonly IProductFlowRepository _productFlowRepository;
        public GetProductFlowQueryHandler(IProductFlowRepository productFlowRepository)
        {
            _productFlowRepository = productFlowRepository;
        }
        #endregion
        public async Task<ApiResponse<List<GetProductFlowResponseDto>>> Handle(GetProductFlowListQuery request, CancellationToken cancellationToken)
        {
            var data = await _productFlowRepository.GetProductFlow(new ProductFlowRequestDto
            {
                FiscalYearId = request.FiscalYearId,
                WarehouseId = request.WarehouseId,
                ProductId = request.ProductId,
                FromDate = request.FromDate,
                ToDate = request.ToDate,
            }, cancellationToken);

            return new ApiResponse<List<GetProductFlowResponseDto>>(true, ApiResponseStatusCode.Success, data, "عملیات با موفقیت انجام شد");
        }
    }
}
