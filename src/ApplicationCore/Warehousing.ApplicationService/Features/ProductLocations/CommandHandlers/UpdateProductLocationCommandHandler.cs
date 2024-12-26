using Warehousing.ApplicationService.Features.ProductLocation.Commands.Update;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.ApplicationService.Features.ProductLocation.CommandHandlers
{
    public class UpdateProductLocationCommandHandler : MediatR.IRequestHandler<UpdateProductLocationCommand, ApiResponse>
    {
        #region Constructor
        private readonly IProductLocationRepository _productLocationRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProductLocationCommandHandler(IProductLocationRepository productLocationRepository,
                                                   IUnitOfWork unitOfWork)
        {
            _productLocationRepository = productLocationRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(UpdateProductLocationCommand request, CancellationToken cancellationToken)
        {
            var data = await _productLocationRepository.GetByIdAsync(request.Id, cancellationToken);

            if (data is null)
                throw new AppException("محصول یافت نشد");

            if (await _productLocationRepository.IsExistProductLocationAddress(request.ProductLocationAddress, request.WarehouseId, cancellationToken))
                throw new AppException("عنوان نمی تواند تکراری باشد");

            ProductLocationProfile.Map(request);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
