using Microsoft.EntityFrameworkCore;
using Warehousing.ApplicationService.Features.Suppliers.Queries;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.ApplicationService.Features.Suppliers.QueryHandlers
{
    public class GetsupplierListQueryHandler : MediatR.IRequestHandler<GetsupplierListQuery, ApiResponse<List<GetSupplierResponseVM>>>
    {
        #region Constructor
        private readonly ISupplierRepository _supplierRepository;
        private readonly IUnitOfWork _unitOfWork;
        public GetsupplierListQueryHandler(ISupplierRepository supplierRepository,
                                           IUnitOfWork unitOfWork)
        {
            _supplierRepository = supplierRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse<List<GetSupplierResponseVM>>> Handle(GetsupplierListQuery request, CancellationToken cancellationToken)
        {
            var data = await _supplierRepository
                                   .FetchIQueryableEntity()
                                   .Select(x => new GetSupplierResponseVM
                                   {
                                       SupplierName = x.SupplierName,
                                       SupplerTel = x.SupplerTel,
                                       SupplerWebsite = x.SupplerWebsite
                                   })
                                   .ToListAsync(cancellationToken);

            return new ApiResponse<List<GetSupplierResponseVM>>(true, ApiResponseStatusCode.Success, data, "عملیات با موفقیت انجام شد");
        }
    }
}
