using MediatR;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;
using Warehousing.ApplicationService.Features.Suppliers.Commands.Delete;

namespace Warehousing.ApplicationService.Features.Suppliers.CommandHandlers
{
    public class DeletesupplierCommandHandler : MediatR.IRequestHandler<DeleteSupplierCommand, ApiResponse>
    {
        #region Constructor
        private readonly ISupplierRepository _supplierRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeletesupplierCommandHandler(ISupplierRepository supplierRepository,
                                           IUnitOfWork unitOfWork)
        {
            _supplierRepository = supplierRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            _supplierRepository.DeleteById(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
