using Microsoft.AspNetCore.Http;
using Warehousing.ApplicationService.Features.ProductLocation.Commands.Create;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common;
using Warehousing.Domain.Freamwork.Extensions;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Warehousing.ApplicationService.Features
{
    public class CreateProductLocationCommandHandler : MediatR.IRequestHandler<CreateProductLocationCommand, ApiResponse>
    {
        #region Constructor
        private readonly IProductLocationRepository _productLocationRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static string _userId = "0";
        private readonly IUnitOfWork _unitOfWork;
        public CreateProductLocationCommandHandler(IProductLocationRepository productLocationRepository,
                                                   IUnitOfWork unitOfWork)
        {
            _productLocationRepository = productLocationRepository;
            _userId = _httpContextAccessor.GetUserId();
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(CreateProductLocationCommand request, CancellationToken cancellationToken)
        {
            if (await _productLocationRepository.IsExistProductLocationAddress(request.ProductLocationAddress,request.WarehouseId, cancellationToken))
                throw new AppException("عنوان نمی تواند تکراری باشد");

            var location = new Warehousing.Domain.Entities.ProductLocation
            {
                WarehouseId = request.WarehouseId,
                ProductLocationAddress = request.ProductLocationAddress,
                CreatorUserId = _userId
            };
            await _productLocationRepository.AddAsync(location, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
