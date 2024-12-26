using Warehousing.ApplicationService.Features.Suppliers.Commands.Create;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.ApplicationService.Features.Suppliers.CommandHandlers
{

    public class CreateSupplierCommandHandler : MediatR.IRequestHandler<CreateSupplierCommand, ApiResponse>
    {
        #region Constructor
        private readonly ISupplierRepository _supplierRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateSupplierCommandHandler(ISupplierRepository supplierRepository,
                                           IUnitOfWork unitOfWork)
        {
            _supplierRepository = supplierRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            if (await _supplierRepository.IsExistSupplierName(request.SupplierName, cancellationToken))
                throw new AppException("عنوان نمی تواند تکراری باشد");

            var mapper = SupplierProfile.Map(request);
            await _supplierRepository.AddAsync(mapper, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
