using Microsoft.AspNetCore.Http;
using Warehousing.ApplicationService.Features.Product.Commands.Update;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common;
using Warehousing.Common.Enums;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Freamwork.Extensions;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.ApplicationService.Features.Product.CommandHandlers
{
    public class UpdateProductCommandHandler : MediatR.IRequestHandler<UpdateProductCommand, ApiResponse>
    {
        #region Constructor
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static string _userId = "0";
        public UpdateProductCommandHandler(IProductRepository productRepository,
                                             IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _userId = _httpContextAccessor.GetUserId();
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var data = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
            if (data is null)
                throw new AppException("محصولی یافت نشد");

                data.ProductName = request.ProductName;
                data.CountInPacking = request.CountInPacking;
                data.CountryId = request.CountryId;
                data.IsRefregrator = request.IsRefregrator;
                data.PackingType = request.PackingType;
                data.ProductImage = request.ProductImage;
                data.ProductWeight = request.ProductWeight;
                data.SupplierId = request.SupplierId;
                data.UpdateDate = DateTime.Now;

            if (data.ProductName != request.ProductName)
            {
                if (await _productRepository.IsExistProductName(request.ProductName, request.ProductCode, cancellationToken))
                    throw new AppException("عنوان نمی تواند تکراری باشد");
            }
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
