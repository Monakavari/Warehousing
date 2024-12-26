using Warehousing.ApplicationService.Features.ProductPrice.Queries;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Features.ProductPrice.ProductPriceQueryHandler
{
    public class GetProductPriceDetailQueryHandler : MediatR.IRequestHandler<GetProductPriceDetailQuery, ApiResponse<GetProductPriceResponseDto>>
    {
        #region Constructor
        private readonly IProductPriceRepository _productPriceRepository;
        public GetProductPriceDetailQueryHandler(IProductPriceRepository productPriceRepository)
        {
            _productPriceRepository = productPriceRepository;
        }
        #endregion
        public async Task<ApiResponse<GetProductPriceResponseDto>> Handle(GetProductPriceDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _productPriceRepository.GetByIdAsync(request.Id, cancellationToken);
            var mapper = ProductPriceProfile.Map(entity);

            return new ApiResponse<GetProductPriceResponseDto>(true, ApiResponseStatusCode.Success, mapper, "عملیات با موفقیت انجام شد");
        }
    }
}
