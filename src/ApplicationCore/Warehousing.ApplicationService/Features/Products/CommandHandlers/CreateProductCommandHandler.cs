using Warehousing.ApplicationService.Features.Product.Commands.Create;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;
using Microsoft.AspNetCore.Http;
using Warehousing.Domain.Freamwork.Extensions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Warehousing.ApplicationService.Features.Product.CommandHandlers
{
    public class CreateProductCommandHandler : MediatR.IRequestHandler<CreateProductCommand, ApiResponse>
    {
        #region Constructor
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static string _userId = "0";
        public CreateProductCommandHandler(IProductRepository productRepository,
                                             IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _userId = _httpContextAccessor.GetUserId();
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (await _productRepository.IsExistProductName(request.ProductName, request.ProductCode, cancellationToken))
                throw new AppException("عنوان نمی تواند تکراری باشد");

            var product = new Warehousing.Domain.Entities.Product
            {
                ProductName = request.ProductName,
                CountInPacking = request.CountInPacking,
                CountryId = request.CountryId,
                IsRefregrator = request.IsRefregrator,
                CreatorUserId = _userId,
                PackingType = request.PackingType,
                ProductImage = request.ProductImage,
                ProductWeight = request.ProductWeight,
                SupplierId = request.SupplierId,
            };
            await _productRepository.AddAsync(product, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
