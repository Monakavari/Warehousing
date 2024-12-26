using Warehousing.ApplicationService.Features.ProductPrice.Queries;
using Warehousing.Common;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Features.ProductPrice.ProductPriceQueryHandler
{
    public class GetProductPriceHistoryQueryHandler : MediatR.IRequestHandler<GetProductPriceHistoryQuery, ApiResponse<List<GetProductPriceResponseDto>>>
    {
        #region Constructor
        private readonly IProductPriceRepository _productPriceRepository;
        public GetProductPriceHistoryQueryHandler(IProductPriceRepository productPriceRepository)
        {
            _productPriceRepository = productPriceRepository;
        }
        #endregion
        public async Task<ApiResponse<List<GetProductPriceResponseDto>>> Handle(GetProductPriceHistoryQuery request, CancellationToken cancellationToken)
        {
            var data = await _productPriceRepository.GetProductPriceHistoryList(request.ProductId, cancellationToken);
            return new ApiResponse<List<GetProductPriceResponseDto>>(true, ApiResponseStatusCode.Success, data, "عملیات با موفقیت انجام شد");
        }
    }
}
