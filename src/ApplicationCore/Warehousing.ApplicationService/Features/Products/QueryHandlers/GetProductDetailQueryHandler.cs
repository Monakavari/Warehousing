using Microsoft.EntityFrameworkCore;
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
            var data = await _productRepository.FetchIQueryableEntity()
                                                       .Where(x => x.Id == request.Id)
                                                       .Select(y => new GetProductResponseVM
                                                       {
                                                           Id = y.Id,
                                                           ProductName = y.ProductName,
                                                           CountInPacking = y.CountInPacking,
                                                           CountryId = y.CountryId,
                                                           IsRefregrator = y.IsRefregrator,
                                                           PackingType = y.PackingType,
                                                           ProductImage = y.ProductImage
                                                       })
                                                       .SingleOrDefaultAsync(cancellationToken);

            return new ApiResponse<GetProductResponseVM>(true, ApiResponseStatusCode.Success, data, "عملیات با موفقیت انجام شد");
        }
    }
}
