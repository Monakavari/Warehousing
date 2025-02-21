using Microsoft.EntityFrameworkCore;
using Warehousing.ApplicationService.Features.ProductLocation.Queries;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Features.ProductLocation.QueryHandlers
{
    public class GetProductLocationListQueryHandler : MediatR.IRequestHandler<GetProductLocationListQuery, ApiResponse<List<GetProductLocationResponseVM>>>
    {
        #region Constructor
        private readonly IProductLocationRepository _productLocationRepository;
        public GetProductLocationListQueryHandler(IProductLocationRepository productLocationRepository)
        {
            _productLocationRepository = productLocationRepository;
        }
        #endregion Constructor
        public async Task<ApiResponse<List<GetProductLocationResponseVM>>> Handle(GetProductLocationListQuery request, CancellationToken cancellationToken)
        {
            var data = await _productLocationRepository.FetchIQueryableEntity()
                                            .Select(x => new GetProductLocationResponseVM
                                            {
                                                Id = x.WarehouseId,
                                                ProductLocationAddress = x.ProductLocationAddress
                                            }).ToListAsync(cancellationToken);

            return new ApiResponse<List<GetProductLocationResponseVM>>(true, ApiResponseStatusCode.Success, data, "عملیات با موفقیت انجام شد");
        }
    }
}
