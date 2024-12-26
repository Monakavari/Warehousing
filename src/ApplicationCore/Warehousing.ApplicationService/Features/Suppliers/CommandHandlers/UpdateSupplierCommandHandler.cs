using Warehousing.ApplicationService.Features.Suppliers.Commands.Update;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.ApplicationService.Features.Suppliers.CommandHandlers
{
    public class UpdatesupplierCommandHandler : MediatR.IRequestHandler<UpdateSupplierCommand, ApiResponse>
    {
        #region Constructor
        private readonly ISupplierRepository _supplierRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdatesupplierCommandHandler(ISupplierRepository supplierRepository,
                                           IUnitOfWork unitOfWork)
        {
            _supplierRepository = supplierRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var data = await _supplierRepository.GetByIdAsync(request.Id, cancellationToken);

            if (data is null)
                throw new AppException("تامین کننده یافت نشد.");

            if (await _supplierRepository.IsExistSupplierName(request.SupplierName, cancellationToken))
                throw new AppException("عنوان نمی تواند تکراری باشد");

            SupplierProfile.Map(request);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
