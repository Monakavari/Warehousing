using Warehousing.ApplicationService.Features.Warehouse.Commands.Update;
using Warehousing.Common;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.DataAccess.EF.Repository;
using Microsoft.AspNetCore.Http;
using Warehousing.Domain.Freamwork.Extensions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Warehousing.ApplicationService.Features.Warehouse.CommandHandlers
{
    public class UpdateWarehouseCommandHandler : MediatR.IRequestHandler<UpdateWarehouseCommand, ApiResponse>
    {
        #region Constructor
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static string _userId = "0";
        public UpdateWarehouseCommandHandler(IWarehouseRepository warehouseRepository,
                                             IUnitOfWork unitOfWork)
        {
            _warehouseRepository = warehouseRepository;
            _unitOfWork = unitOfWork;
            _userId = _httpContextAccessor.GetUserId();
        }
        #endregion
        public async Task<ApiResponse> Handle(UpdateWarehouseCommand request, CancellationToken cancellationToken)
        {
            var data = await _warehouseRepository.GetByIdAsync(request.Id, cancellationToken);
            if (data is null)
                throw new AppException("انباری یافت نشد");

            data.WarehouseName = request.WarehouseName;
            data.WarehouseAddress = request.WarehouseAddress;
            data.WarehouseTel = request.WarehouseTel;
            data.UpdateDate = DateTime.Now;

            if (data.WarehouseName != request.WarehouseName)
            {
                if (await _warehouseRepository.IsExistWarehouse(request.WarehouseName, request.WarehouseAddress, cancellationToken))
                    throw new AppException("عنوان نمی تواند تکراری باشد");
            }
            WarehouseProfile.Map(data);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
