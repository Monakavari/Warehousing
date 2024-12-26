using MediatR;
using Warehousing.ApplicationService.Features.ProductPrice.Commands;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Features.ProductPrice.CommandHandler
{
    public class CreateProductPriceCommandHandler : IRequestHandler<CreateProductPriceCommand, ApiResponse>
    {
        #region Constructor
        private readonly IProductPriceRepository _productPriceRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateProductPriceCommandHandler(IProductPriceRepository productPriceRepository,
                                             IUnitOfWork unitOfWork)
        {
            _productPriceRepository = productPriceRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(CreateProductPriceCommand request, CancellationToken cancellationToken)
        {
            if (await _productPriceRepository.GetProductPrice(request.ProductId, cancellationToken))
                throw new AppException("تاریخ شروع قیمت تکراریست.");

            var mapper = ProductPriceProfile.Map(request);
            await _productPriceRepository.AddAsync(mapper, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
