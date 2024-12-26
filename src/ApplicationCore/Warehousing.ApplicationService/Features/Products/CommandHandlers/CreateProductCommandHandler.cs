using Warehousing.ApplicationService.Features.Product.Commands.Create;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Features.Product.CommandHandlers
{
    public class CreateProductCommandHandler : MediatR.IRequestHandler<CreateProductCommand, ApiResponse>
    {
        #region Constructor
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateProductCommandHandler(IProductRepository productRepository,
                                             IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (await _productRepository.IsExistProductName(request.ProductName,request.ProductCode, cancellationToken))
                throw new AppException("عنوان نمی تواند تکراری باشد");

            var mapper = ProductProfile.Map(request);
            await _productRepository.AddAsync(mapper, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
