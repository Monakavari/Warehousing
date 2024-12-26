using MediatR;
using Warehousing.ApplicationService.Features.Suppliers.Queries;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.ApplicationService.Features.Suppliers.QueryHandlers
{
    public class GetSupplierDetailQueryHandler : MediatR.IRequestHandler<GetSupplierDetailQuery, ApiResponse<GetSupplierResponseVM>>
    {
        #region Constructor
        private readonly ISupplierRepository _supplierRepository;
        private readonly IUnitOfWork _unitOfWork;
        public GetSupplierDetailQueryHandler(ISupplierRepository supplierRepository,
                                           IUnitOfWork unitOfWork)
        {
            _supplierRepository = supplierRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse<GetSupplierResponseVM>> Handle(GetSupplierDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _supplierRepository.GetByIdAsync(request.Id, cancellationToken);
            var mapper = SupplierProfile.Map(entity);

            return new ApiResponse<GetSupplierResponseVM>(true, ApiResponseStatusCode.Success, mapper, "عملیات با موفقیت انجام شد");
        }
    }
}
