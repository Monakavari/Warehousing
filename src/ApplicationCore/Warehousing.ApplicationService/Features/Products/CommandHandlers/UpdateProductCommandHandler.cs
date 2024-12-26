using Warehousing.ApplicationService.Features.Product.Commands.Update;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.ApplicationService.Features.Product.CommandHandlers
{
    public class UpdateProductCommandHandler : MediatR.IRequestHandler<UpdateProductCommand, ApiResponse>
    {
        #region Constructor
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProductCommandHandler(IProductRepository productRepository,
                                             IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var data = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
            if (data is null)
                throw new AppException("محصولی یافت نشد");

            if (await _productRepository.IsExistProductName(request.ProductName,request.ProductCode, cancellationToken))
                throw new AppException("عنوان نمی تواند تکراری باشد");
            ProductProfile.Map(data);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
