using Microsoft.EntityFrameworkCore;
using Warehousing.ApplicationService.Features.Product.Queries;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Features.Product.QueryHandlers
{
    internal class GetProductListQueryHandler : MediatR.IRequestHandler<GetProductListQuery, ApiResponse<List<GetProductResponseVM>>>
    {
        #region Constructor
        private readonly IProductRepository _productRepository;
        public GetProductListQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion
        public async Task<ApiResponse<List<GetProductResponseVM>>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {

            var data = await _productRepository
                                    .FetchIQueryableEntity()
                                    .Select(x => new GetProductResponseVM
                                    {
                                        Id = x.Id,
                                        ProductName = x.ProductName,
                                        CountInPacking = x.CountInPacking,
                                        CountryId = x.CountryId,
                                        IsRefregrator = x.IsRefregrator,
                                        PackingType = x.PackingType,
                                        ProductImage = x.ProductImage,
                                        ProductWeight = x.ProductWeight,
                                        SupplierId = x.SupplierId
                                    })
                                    .ToListAsync(cancellationToken);

            return new ApiResponse<List<GetProductResponseVM>>(true, ApiResponseStatusCode.Success, data, "عملیات با موفقیت انجام شد");
        }
    }
}
