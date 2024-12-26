using Warehousing.ApplicationService.Features.ProductLocation.Commands.Create;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.ApplicationService.Features
{
    public class CreateProductLocationCommandHandler : MediatR.IRequestHandler<CreateProductLocationCommand, ApiResponse>
    {
        #region Constructor
        private readonly IProductLocationRepository _productLocationRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateProductLocationCommandHandler(IProductLocationRepository productLocationRepository,
                                                   IUnitOfWork unitOfWork)
        {
            _productLocationRepository = productLocationRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(CreateProductLocationCommand request, CancellationToken cancellationToken)
        {
            if (await _productLocationRepository.IsExistProductLocationAddress(request.ProductLocationAddress,request.WarehouseId, cancellationToken))
                throw new AppException("عنوان نمی تواند تکراری باشد");

            var mapper = ProductLocationProfile.Map(request);
            await _productLocationRepository.AddAsync(mapper, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
