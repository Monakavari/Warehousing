using Warehousing.ApplicationService.Features.ProductLocations.Queries;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Features.ProductLocations.QueryHandlers
{
    public class GetProductLocationDetailQueryHandler : MediatR.IRequestHandler<GetProductLocationDetailQuery, ApiResponse<ProductLocationResponseDto>>
    {
        #region Constructor
        private readonly IProductLocationRepository _productLocationRepository;
        public GetProductLocationDetailQueryHandler(IProductLocationRepository productLocationRepository)
        {
            _productLocationRepository = productLocationRepository;
        }
        #endregion Constructor
        public async Task<ApiResponse<ProductLocationResponseDto>> Handle(GetProductLocationDetailQuery request, CancellationToken cancellationToken)
        {
            var data = await _productLocationRepository.GetProductLocationById(request.Id, cancellationToken);
            return new ApiResponse<ProductLocationResponseDto>(true, ApiResponseStatusCode.Success, data, "عملیات با موفقیت انجام شد");
        }
    }
}
