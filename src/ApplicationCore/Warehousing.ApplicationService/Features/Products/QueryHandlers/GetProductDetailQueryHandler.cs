using Warehousing.ApplicationService.Features.Product.Queries;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Features.Product.QueryHandlers
{
    public class GetProductDetailQueryHandler : MediatR.IRequestHandler<GetProductDetailQuery, ApiResponse<GetProductResponseVM>>
    {
        #region Constructor
        private readonly IProductRepository _productRepository;
        public GetProductDetailQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion
        public async Task<ApiResponse<GetProductResponseVM>> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
            var mapper = ProductProfile.Map(entity);

            return new ApiResponse<GetProductResponseVM>(true, ApiResponseStatusCode.Success, mapper, "عملیات با موفقیت انجام شد");
        }
    }
}
