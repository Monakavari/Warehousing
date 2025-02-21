using Microsoft.AspNetCore.Http;
using Warehousing.ApplicationService.Features.ProductLocation.Commands.Update;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Freamwork.Extensions;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Warehousing.ApplicationService.Features.ProductLocation.CommandHandlers
{
    public class UpdateProductLocationCommandHandler : MediatR.IRequestHandler<UpdateProductLocationCommand, ApiResponse>
    {
        #region Constructor
        private readonly IProductLocationRepository _productLocationRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static string _userId = "0";
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProductLocationCommandHandler(IProductLocationRepository productLocationRepository,
                                                   IUnitOfWork unitOfWork)
        {
            _productLocationRepository = productLocationRepository;
            _userId = _httpContextAccessor.GetUserId();
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(UpdateProductLocationCommand request, CancellationToken cancellationToken)
        {
            var data = await _productLocationRepository.GetByIdAsync(request.Id, cancellationToken);

            if (data is null)
                throw new AppException("محصول یافت نشد");

            data.WarehouseId = request.WarehouseId;
            data.ProductLocationAddress = request.ProductLocationAddress;
            data.ModifierUserId = _userId;
            data.UpdateDate = DateTime.Now;

            if (data.ProductLocationAddress != request.ProductLocationAddress)
            {
                if (await _productLocationRepository.IsExistProductLocationAddress(request.ProductLocationAddress, request.WarehouseId, cancellationToken))
                    throw new AppException("عنوان نمی تواند تکراری باشد");
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
