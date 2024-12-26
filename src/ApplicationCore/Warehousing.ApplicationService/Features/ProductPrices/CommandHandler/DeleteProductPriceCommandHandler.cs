using Warehousing.ApplicationService.Features.ProductPrice.Commands.Delete;
using Warehousing.Common;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.ApplicationService.Features.ProductPrice.CommandHandler
{
    public class DeleteProductPriceCommandHandler : MediatR.IRequestHandler<DeleteProductPriceCommand, ApiResponse>
    {
        #region Constructor
        private readonly IProductPriceRepository _productPriceRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProductPriceCommandHandler(IProductPriceRepository productPriceRepository,
                                             IUnitOfWork unitOfWork)
        {
            _productPriceRepository = productPriceRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(DeleteProductPriceCommand request, CancellationToken cancellationToken)
        {
            if (!await _productPriceRepository.HasNotActionDateArrived(cancellationToken))
                throw new AppException("تاریخ اعمال قیمت منقضی شده است.");

            _productPriceRepository.DeleteById(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
