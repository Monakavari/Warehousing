using Microsoft.AspNetCore.Http;
using Warehousing.ApplicationService.Features.Suppliers.Commands.Update;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common;
using Warehousing.Domain.Freamwork.Extensions;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Warehousing.ApplicationService.Features.Suppliers.CommandHandlers
{
    public class UpdatesupplierCommandHandler : MediatR.IRequestHandler<UpdateSupplierCommand, ApiResponse>
    {
        #region Constructor
        private readonly ISupplierRepository _supplierRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static string _userId = "0";
        private readonly IUnitOfWork _unitOfWork;
        public UpdatesupplierCommandHandler(ISupplierRepository supplierRepository,
                                           IUnitOfWork unitOfWork)
        {
            _supplierRepository = supplierRepository;
            _userId = _httpContextAccessor.GetUserId();
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var data = await _supplierRepository.GetByIdAsync(request.Id, cancellationToken);

            if (data is null)
                throw new AppException("تامین کننده یافت نشد.");

            data.UpdateDate = DateTime.Now;
            data.SupplierName = request.SupplierName;
            data.SupplerTel = request.SupplerTel;
            data.SupplerWebsite = request.SupplerWebsite;
            data.ModifierUserId = _userId;
            data.UpdateDate = DateTime.Now;

            if (data.SupplierName != request.SupplierName)
            {
                if (await _supplierRepository.IsExistSupplierName(request.SupplierName, request.SupplerWebsite, cancellationToken))
                    throw new AppException("عنوان نمی تواند تکراری باشد");
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
