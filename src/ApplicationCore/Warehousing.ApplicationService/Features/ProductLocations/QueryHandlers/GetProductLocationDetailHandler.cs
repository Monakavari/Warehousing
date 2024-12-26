using Microsoft.EntityFrameworkCore;
using Warehousing.ApplicationService.Features.ProductLocation.Queries;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Features.ProductLocation.QueryHandlers
{
    public class GetProductLocationDetailHandler : MediatR.IRequestHandler<GetProductLocationDetailQuery, ApiResponse<List<GetProductLocationResponseVM>>>
    {
        #region Constructor
        private readonly IProductLocationRepository _productLocationRepository;
        public GetProductLocationDetailHandler(IProductLocationRepository productLocationRepository)
        {
            _productLocationRepository = productLocationRepository;
        }
        #endregion Constructor
        public async Task<ApiResponse<List<GetProductLocationResponseVM>>> Handle(GetProductLocationDetailQuery request, CancellationToken cancellationToken)
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
