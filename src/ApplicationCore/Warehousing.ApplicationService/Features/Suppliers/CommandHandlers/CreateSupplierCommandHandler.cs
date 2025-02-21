using Microsoft.AspNetCore.Http;
using Warehousing.ApplicationService.Features.Suppliers.Commands.Create;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Freamwork.Extensions;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Warehousing.ApplicationService.Features.Suppliers.CommandHandlers
{

    public class CreateSupplierCommandHandler : MediatR.IRequestHandler<CreateSupplierCommand, ApiResponse>
    {
        #region Constructor
        private readonly ISupplierRepository _supplierRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static string _userId = "0";
        public CreateSupplierCommandHandler(ISupplierRepository supplierRepository,
                                           IUnitOfWork unitOfWork)
        {
            _supplierRepository = supplierRepository;
            _userId = _httpContextAccessor.GetUserId();
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            if (await _supplierRepository.IsExistSupplierName(request.SupplierName, cancellationToken))
                throw new AppException("عنوان نمی تواند تکراری باشد");

            var supplier = new Supplier
            {
                SupplierName = request.SupplierName,
                SupplerTel = request.SupplerTel,
                SupplerWebsite = request.SupplerWebsite,
                CreatorUserId = _userId
            };

            await _supplierRepository.AddAsync(supplier, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
